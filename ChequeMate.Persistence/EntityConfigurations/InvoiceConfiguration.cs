using Microsoft.EntityFrameworkCore;
using ChequeMate.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChequeMate.Persistence.EntityConfigurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.HasMany(e => e.ListItems)
            .WithOne(e => e.Invoice)
            .HasForeignKey(e => e.InvoiceId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CustomerName).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();
        builder.Property(p => p.IsPaid).IsRequired().HasDefaultValue(false);
    }
}