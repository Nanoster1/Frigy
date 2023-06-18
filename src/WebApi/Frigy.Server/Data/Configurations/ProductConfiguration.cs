using Frigy.Server.Data.Configurations.Common;
using Frigy.Server.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frigy.Server.Data.Configurations;

public class ProductConfiguration : EntityBaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.ProductCategory).IsRequired();
        builder.Property(e => e.IsImportant).IsRequired();
        builder.Property(e => e.Count).IsRequired();
        builder.Property(e => e.MaxCount).IsRequired();
    }
}