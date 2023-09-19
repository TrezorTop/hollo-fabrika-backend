using HolloFabrika.Feature;
using HolloFabrika.Feature.Test;
using HolloFabrika.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    DotNetEnv.Env.TraversePath().Load();
}

builder.Services.AddInfrastructure();
builder.Services.AddFeatures();

var app = builder.Build();
await app.Services.InfrastructureInitAsync();

app.MapGet("/", async (TestFeature testFeature) =>
{
    var result = await testFeature.Get();

    if (result.IsFailed)
        return Results.BadRequest(result.Reasons);

    return Results.Ok(result.Value);
});

app.MapPost("/", async (TestFeature testFeature) =>
{
    var result = await testFeature.Create();

    if (result.IsFailed)
        return Results.BadRequest(result.Reasons);

    return Results.Ok(result.Value);
});

app.Run();