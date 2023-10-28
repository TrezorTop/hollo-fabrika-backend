using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Features.Attributes;

public class GetByIdAttributeFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public GetByIdAttributeFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Attribute>> GetByIdAsync(string id)
    {
        var attribute = await _applicationDatabase.Attributes.FirstOrDefaultAsync(x => id == x.Id.ToString());

        if (attribute == null) return Result.Fail("Not found");

        return Result.Ok(attribute);
    }
}