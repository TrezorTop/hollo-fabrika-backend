using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Products;

namespace HolloFabrika.Api.Endpoints.Products;

public class Get : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Products.Get, async (GetProductFeature getProductFeature) =>
        {
            var result = await getProductFeature.GetAsync();

            return Results.Ok(result.Value);
        });
    }
}