using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Dto;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Endpoints.Categories;

public class GetById : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.GetById, async (string id, GetByIdCategoryFeature getByIdCategoryFeature) =>
        {
            var result = await getByIdCategoryFeature.GetByIdAsync(id);

            if (result.IsFailed) return Results.NotFound(result.Reasons);

            return Results.Ok(new CategoryResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Attributes = result.Value.Attributes.Select(x => new CategoryAttributeResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
            });
        });
    }
}