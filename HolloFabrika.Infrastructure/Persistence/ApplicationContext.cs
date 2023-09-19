using HolloFabrika.Feature.Interfaces;
using HolloFabrika.Feature.Test;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Infrastructure.Persistence;

public class ApplicationContext : DbContext, IApplicationDatabase
{
    public DbSet<TestModel> Tests => Set<TestModel>();

    public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
}