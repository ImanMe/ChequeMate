using ChequeMate.API.Features.Invoice.Commands.CreateInvoice;
using System.Reflection;
using FluentValidation;
using ChequeMate.Domain.Contracts;
using ChequeMate.Persistence.Contracts;
using ChequeMate.Persistence.Repositories;
using ChequeMate.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChequeMate.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<CreateInvoiceCommandValidator>();
        services.AddControllers();
        services.AddSwagger();
    }

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContext(configuration);
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddScoped<IInvoiceUnitOfWork, InvoiceUnitOfWork>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    }

    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ChequeMateConnection");

        services.AddDbContext<InvoiceContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
    }
}