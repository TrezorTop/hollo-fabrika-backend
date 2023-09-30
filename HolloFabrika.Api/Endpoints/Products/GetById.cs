using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Products;

namespace HolloFabrika.Api.Endpoints.Products;

public class GetById : IEndpoint

{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Products.GetById, async (string id, GetByIdProductFeature getByIdProductFeature) =>
        {
            var result = await getByIdProductFeature.GetByIdAsync(id);

            if (result.IsFailed) return Results.NotFound(result.Reasons);

            return Results.Ok(result.Value);
        });
    }
}