using ChequeMate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChequeMate.Persistence;

public class InvoiceContext : DbContext
{
    public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<ListItem> ListItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}