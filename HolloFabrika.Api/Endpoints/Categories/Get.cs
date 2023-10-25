using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Endpoints.Categories;

public class Get : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.Get, async (GetCategoryFeature getCategoryFeature) =>
        {
            var result = await getCategoryFeature.GetAsync();

            return Results.Ok(result.Value.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Attributes = category.Attributes.Select(attribute => new AttributeResponse
                {
                    Id = attribute.Id,
                    Name = attribute.Name,
                    CategoryId = category.Id,
                }).ToList(),
            }));
        });
    }
}