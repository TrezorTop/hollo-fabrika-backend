using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Products;

namespace HolloFabrika.Api.Endpoints.Products;

public class CreateProduct : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Products.Create, async (CreateProductDto productDto, CreateProductFeature createProductFeature) =>
        {
            var result = await createProductFeature.Create(productDto.ToProduct());

            if (result.IsFailed) return Results.BadRequest(result.Reasons);

            return Results.Ok(result.Value);
        });
    }
}

public class CreateProductDto
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