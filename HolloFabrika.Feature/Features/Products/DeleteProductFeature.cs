using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Products;

public class DeleteProductFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public DeleteProductFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Product>> DeleteAsync(string id)
    {
        var product = await _applicationDatabase.Products.FirstOrDefaultAsync(x => x.Id.ToString() == id);

        if (product == null) return Result.Fail("Product not found");

        _applicationDatabase.Products.Remove(product);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(product);
    }
}