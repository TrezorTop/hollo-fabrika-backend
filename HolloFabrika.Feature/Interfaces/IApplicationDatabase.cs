using HolloFabrika.Feature.Entities;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Interfaces;

public interface IApplicationDatabase
{
    DbSet<Product> Products { get; }
    DbSet<Category> Categories { get; }
    DbSet<Attribute> Attributes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}