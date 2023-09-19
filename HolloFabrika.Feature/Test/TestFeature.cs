using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Test;

public sealed class TestFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public TestFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<List<TestModel>>> Get()
    {
        var tests = await _applicationDatabase.Tests.ToListAsync();

        return tests;
    }

    public async Task<Result<TestModel>> Create()
    {
        var model = new TestModel
        {
            Message = "Message"
        };

        _applicationDatabase.Tests.Add(model);

        await _applicationDatabase.SaveChangesAsync();

        return model;
    }
}