using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;

namespace HolloFabrika.Feature.Features.Categories;

public class CreateCategoryFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public CreateCategoryFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Category>> CreateAsync(Category category)
    {
        _applicationDatabase.Categories.Add(category);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(category);
    }
}