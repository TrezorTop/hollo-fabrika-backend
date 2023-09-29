using FluentResults;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HolloFabrika.Feature.Features.Products;

public class GetProductFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetProductFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<List<Product>>> GetAsync()
    {
        var products = await _applicationDatabase.Products.ToListAsync();

        return Result.Ok(products);
    }
}