using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Products;

public class GetByIdProductFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetByIdProductFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Product>> GetByIdAsync(string guid)
    {
        var product = await _applicationDatabase.Products.FirstOrDefaultAsync(x => x.Id.ToString() == guid);

        if (product == null) return Result.Fail("Product not found");

        return Result.Ok(product);
    }
}