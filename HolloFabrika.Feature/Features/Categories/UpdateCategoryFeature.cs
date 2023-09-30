using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Categories;

public class UpdateCategoryFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public UpdateCategoryFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Category>> UpdateAsync(Category category)
    {
        var oldCategory = await _applicationDatabase.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

        if (oldCategory == null) return Result.Fail("Not found");

        _applicationDatabase.Categories.Update(category);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(category);
    }
}