using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;

namespace HolloFabrika.Feature.Features.Products;

public class CreateProductFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public CreateProductFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Product>> Create(Product product)
    {
        _applicationDatabase.Products.Add(product);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(product);
    }
}