using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Infrastructure.Persistence;

public class ApplicationContext : DbContext, IApplicationDatabase
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Attribute> Attributes => Set<Attribute>();

    public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}