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
        var category = await _applicationDatabase.Categories
            .Include(x => x.Attributes)
            .FirstOrDefaultAsync(x => id == x.Id.ToString());

        if (category == null) return Result.Fail("Not found");

        return Result.Ok(category);
    }
}