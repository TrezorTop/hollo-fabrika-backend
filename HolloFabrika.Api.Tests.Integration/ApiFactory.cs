using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HolloFabrika.Api.Tests.Integration;

public class ApiFactory : WebApplicationFactory<IApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    }
}