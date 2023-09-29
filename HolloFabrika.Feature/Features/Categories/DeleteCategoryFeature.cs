using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;

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
        var category = _applicationDatabase.Categories.FirstOrDefault(x => id == x.Id.ToString());

        if (category == null) return Result.Fail("Category not found");

        _applicationDatabase.Categories.Remove(category);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(category);
    }
}