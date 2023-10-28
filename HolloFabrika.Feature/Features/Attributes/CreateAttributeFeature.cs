using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Features.Attributes;

public class CreateAttributeFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public CreateAttributeFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }
    
    public async Task<Result<Attribute>> CreateAsync(Attribute attribute)
    {
        this._applicationDatabase.Attributes.Add(attribute);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(attribute);
    }
}