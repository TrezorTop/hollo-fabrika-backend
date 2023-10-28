using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Products;

namespace HolloFabrika.Api.Endpoints.Products;

public class CreateProduct : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Products.Create, async (CreateProductRequest productRequest, CreateProductFeature createProductFeature) =>
        {
            var result = await createProductFeature.CreateAsync(productRequest.ToProduct());

            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

            return Results.Ok(result.Value);
        });
    }
}

public class CreateProductRequest
{
    public required string Name { get; set; }

    public Product ToProduct()
    {
        return new Product
        {
            Name = Name
        };
    }
}