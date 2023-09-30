using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Categories;

public class GetCategoryFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetCategoryFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<List<Category>>> GetAsync()
    {
        var categories = await _applicationDatabase.Categories.Include(x => x.Attributes).ToListAsync();

        return Result.Ok(categories);
    }
}