using HolloFabrika.Feature.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Infrastructure.Persistence.Configs;

internal class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(AttributeConstants.NameMaxLength)
            .IsRequired();

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Attributes)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property<byte[]>("TimeStamp")
            .IsRowVersion();
    }
}