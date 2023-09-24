using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;

namespace HolloFabrika.Feature.Features.Products;

public class DeleteProductFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public DeleteProductFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Product>> Delete(string guid)
    {
        var product = _applicationDatabase.Products.FirstOrDefault(x => x.Id.ToString() == guid);

        if (product == null) return Result.Fail("Product not found");

        _applicationDatabase.Products.Remove(product);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(product);
    }
}