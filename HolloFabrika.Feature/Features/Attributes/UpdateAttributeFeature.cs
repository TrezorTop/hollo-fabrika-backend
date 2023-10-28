using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Features.Attributes;

public class UpdateAttributeFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public UpdateAttributeFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Attribute>> UpdateAsync(Attribute attribute)
    {
        var oldAttribute = await _applicationDatabase.Attributes.FirstOrDefaultAsync(x => x.Id == attribute.Id);

        if (oldAttribute == null) return Result.Fail("Not found");

        oldAttribute.Name = attribute.Name;

        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(attribute);
    }
}