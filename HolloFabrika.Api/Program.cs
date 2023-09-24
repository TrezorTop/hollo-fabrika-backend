using DotNetEnv;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature;
using HolloFabrika.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    Env.TraversePath().Load();
}

builder.Services.AddInfrastructure();
builder.Services.AddFeatures();

var app = builder.Build();
await app.Services.InfrastructureInitAsync();

app.UseEndpoints();

app.Run();