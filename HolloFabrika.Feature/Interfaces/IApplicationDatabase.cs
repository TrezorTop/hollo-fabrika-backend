using HolloFabrika.Feature.Test;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Interfaces;

public interface IApplicationDatabase
{
    DbSet<TestModel> Tests { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}