using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Attributes;

namespace HolloFabrika.Api.Endpoints.Attributes;

public class GetAttribute : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Attributes.Get, async (GetAttributeFeature getAttributeFeature) =>
            {
                var result = await getAttributeFeature.GetAsync();

                return Results.Ok(result.Value.Select(attribute => new AttributeResponse
                {
                    Id = attribute.Id,
                    Name = attribute.Name,
                    CategoryId = attribute.CategoryId
                }));
            })
            .Produces<IEnumerable<AttributeResponse>>(StatusCodes.Status200OK)
            .WithTags(Tags.Attributes);
    }
}