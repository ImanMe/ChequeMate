using Microsoft.EntityFrameworkCore;
using ChequeMate.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChequeMate.Persistence.EntityConfigurations;

public class ListItemConfiguration : IEntityTypeConfiguration<ListItem>
{
    public void Configure(EntityTypeBuilder<ListItem> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
    }
}