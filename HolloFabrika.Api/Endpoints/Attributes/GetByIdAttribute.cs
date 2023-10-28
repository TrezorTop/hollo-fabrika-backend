using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Features.Attributes;

namespace HolloFabrika.Api.Endpoints.Attributes;

public class GetByIdAttribute : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Attributes.GetById, async (string id, GetByIdAttributeFeature getByIdAttributeFeature) =>
        {
            var result = await getByIdAttributeFeature.GetByIdAsync(id);

            if (result.IsFailed) return Results.NotFound(result.ToErrorResponse());

            return Results.Ok(new AttributeResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                CategoryId = result.Value.CategoryId
            });
        })
            .Produces<AttributeResponse>(StatusCodes.Status200OK)
            .Produces<ErrorResponse>(StatusCodes.Status404NotFound)
            .WithTags(Tags.Attributes);
    }
}