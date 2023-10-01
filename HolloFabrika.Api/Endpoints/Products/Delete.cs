using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Features.Products;

namespace HolloFabrika.Api.Endpoints.Products;

public class Delete : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoutes.Products.Delete, async (string id, DeleteProductFeature deleteProductFeature) =>
        {
            var result = await deleteProductFeature.DeleteAsync(id);

            if (result.IsFailed) return Results.NotFound(result.ToErrorResponse());

            return Results.Ok(result.Value);
        });
    }
}