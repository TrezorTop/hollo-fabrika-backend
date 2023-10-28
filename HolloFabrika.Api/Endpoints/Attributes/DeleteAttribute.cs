using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Features.Attributes;

namespace HolloFabrika.Api.Endpoints.Attributes;

public class DeleteAttribute : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoutes.Attributes.Delete, async (string id, DeleteAttributeFeature deleteAttributeFeature) =>
        {
            var result = await deleteAttributeFeature.DeleteAsync(id);

            if (result.IsFailed) return Results.NotFound(result.ToErrorResponse());

            return Results.Ok(new AttributeResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                CategoryId = result.Value.CategoryId
            });
        });
    }
}