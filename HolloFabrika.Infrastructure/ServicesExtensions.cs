using HolloFabrika.Feature.Interfaces;
using HolloFabrika.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace HolloFabrika.Infrastructure;

public static class ServicesExtensions
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<ApplicationContext>(ConfigureNpgsql);
        serviceCollection.AddScoped<IApplicationDatabase>(provider => provider.GetRequiredService<ApplicationContext>());
    }

    public static async Task InfrastructureInitAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        await context.Database.MigrateAsync();
    }

    internal static void ConfigureNpgsql(DbContextOptionsBuilder builder)
    {
        var connectionString = new NpgsqlConnectionStringBuilder
            {
                Port = 5432,
                Host = Environment.GetEnvironmentVariable("POSTGRES_HOST"),
                Database = Environment.GetEnvironmentVariable("POSTGRES_DATABASE"),
                Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"),
                Username = Environment.GetEnvironmentVariable("POSTGRES_USER"),
                Pooling = true,
            }
            .ToString();

        builder.UseNpgsql(connectionString);
    }
}