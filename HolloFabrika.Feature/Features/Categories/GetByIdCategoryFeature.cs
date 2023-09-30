using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Categories;

public class GetByIdCategoryFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetByIdCategoryFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Category>> GetByIdAsync(string id)
    {
        var product = await _applicationDatabase.Categories.Include(x => x.Attributes).FirstOrDefaultAsync(x => id == x.Id.ToString());

        if (product == null) return Result.Fail("Category not found");

        return Result.Ok(product);
    }
}