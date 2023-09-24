using HolloFabrika.Feature.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Interfaces;

public interface IApplicationDatabase
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}