using System.Reflection;
using System.Runtime.CompilerServices;
using ChequeMate.API.Extensions;
using ChequeMate.API.Features.Invoice.Commands.CreateInvoice;
using ChequeMate.API.Middleware;
using ChequeMate.Domain.Contracts;
using ChequeMate.Persistence;
using ChequeMate.Persistence.Contracts;
using ChequeMate.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string chequeMateCorsPolicy = "_chequeMateCorsPolicy";

builder.Services.AddCors(options =>
{
    // TODO: Limit CORS to specific client URL 
    options.AddPolicy(chequeMateCorsPolicy,
        o => { o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseCors(chequeMateCorsPolicy);

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Migrate database at runtime
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var context = services.GetRequiredService<InvoiceContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration");
}

await app.RunAsync();
