using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HolloFabrika.Infrastructure.Persistence;

public class ApplicationContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder();

        Env.TraversePath().Load();

        ServicesExtensions.ConfigureNpgsql(builder);

        return new ApplicationContext(builder.Options);
    }
}