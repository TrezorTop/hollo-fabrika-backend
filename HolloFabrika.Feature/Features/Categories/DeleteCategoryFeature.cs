using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Categories;

public class DeleteCategoryFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public DeleteCategoryFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Category>> DeleteAsync(string id)
    {
        var category = await _applicationDatabase.Categories
            .Include(x => x.Attributes)
            .FirstOrDefaultAsync(x => id == x.Id.ToString());

        if (category is null) return Result.Fail("Not found");

        _applicationDatabase.Categories.Remove(category);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(category);
    }
}