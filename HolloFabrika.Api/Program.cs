using System.Text.Json;
using FluentResults;
using HolloFabrika.Feature.Test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var result = Test.GetTest();

    if (result.IsFailed)
    {
        return Results.BadRequest(result.Reasons);
    }

    return Results.Ok(result.Value);
});

app.Run();