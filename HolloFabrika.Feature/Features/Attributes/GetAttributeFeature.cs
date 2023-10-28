using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Features.Attributes;

public class GetAttributeFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetAttributeFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<List<Attribute>>> GetAsync()
    {
        
        var attributes = await _applicationDatabase.Attributes.ToListAsync();

        return Result.Ok(attributes);
    }
}