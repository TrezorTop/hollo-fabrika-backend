using DotNetEnv;
using FluentValidation;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Api.Middleware;
using HolloFabrika.Feature;
using HolloFabrika.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    Env.TraversePath().Load();
}

builder.Services.AddInfrastructure();
builder.Services.AddFeatures();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
// builder.Services.AddScoped<ExceptionMiddleware>();

var app = builder.Build();
await app.Services.InfrastructureInitAsync();

// app.UseMiddleware<ExceptionMiddleware>();

app.UseEndpoints();

app.Run();