using HolloFabrika.Api.Contracts;
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

            return Results.Ok(result.Value.Select(x => new CategoryDto.CategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Attributes = x.Attributes.Select(x => new CategoryDto.CategoryAttributeResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Value = x.Value
                }).ToList(),
            }));
        });
    }
}