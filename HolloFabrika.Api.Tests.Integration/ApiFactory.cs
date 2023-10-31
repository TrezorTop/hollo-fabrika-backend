using System.Data.Common;
using HolloFabrika.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HolloFabrika.Api.Tests.Integration;

public class ApiFactory : WebApplicationFactory<IApiMarker>
{
    private DbContext _dbContext;

    public DbConnection GetDbConnection()
    {
        return _dbContext.Database.GetDbConnection();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var serviceProvider = services.BuildServiceProvider();

            _dbContext = serviceProvider.GetRequiredService<ApplicationContext>();
        });
    }
}