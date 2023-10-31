using System.Data.Common;
using HolloFabrika.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Respawn.Graph;
using Xunit;

namespace HolloFabrika.Api.Tests.Integration;

public class RespawnerFactory : ApiFactory, IAsyncLifetime
{
    private Respawner _respawner;

    private DbConnection _connection;

    public async Task InitializeAsync()
    {
        await using var scope = Services.CreateAsyncScope();
        var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        _connection = new NpgsqlConnection(applicationContext.Database.GetConnectionString());
        await _connection.OpenAsync();
        _respawner = await Respawner.CreateAsync(_connection, new RespawnerOptions()
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = new[] { "public" },
            TablesToIgnore = new Table[] { new Table("__EFMigrationsHistory") }
        });
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _respawner.ResetAsync(_connection);
    }
}