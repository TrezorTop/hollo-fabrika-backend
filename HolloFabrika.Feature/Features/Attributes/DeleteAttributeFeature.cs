using FluentResults;
using HolloFabrika.Feature.Interfaces;
using Microsoft.EntityFrameworkCore;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Feature.Features.Attributes;

public class DeleteAttributeFeature : IFeatureMarker
{
    private readonly IApplicationDatabase _applicationDatabase;

    public DeleteAttributeFeature(IApplicationDatabase applicationDatabase)
    {
        _applicationDatabase = applicationDatabase;
    }

    public async Task<Result<Attribute>> DeleteAsync(string id)
    {
        var attribute = await _applicationDatabase.Attributes.FirstOrDefaultAsync(x => id == x.Id.ToString());

        if (attribute is null) return Result.Fail("Not found");

        _applicationDatabase.Attributes.Remove(attribute);
        await _applicationDatabase.SaveChangesAsync();

        return Result.Ok(attribute);
    }
}