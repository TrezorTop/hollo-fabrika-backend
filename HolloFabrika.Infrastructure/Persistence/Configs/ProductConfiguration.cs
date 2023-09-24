using HolloFabrika.Feature.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HolloFabrika.Infrastructure.Persistence.Configs;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey((x) => x.Id);

        builder.Property((x) => x.Name).HasMaxLength(ProductConstants.NameMaxLength).IsRequired();

        builder.Property<byte[]>("TimeStamp").IsRowVersion();
    }
}