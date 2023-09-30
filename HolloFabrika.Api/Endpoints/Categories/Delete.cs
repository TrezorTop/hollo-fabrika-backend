using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Dto;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Endpoints.Categories;

public class Delete : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoutes.Categories.Delete, async (string id, DeleteCategoryFeature deleteCategoryFeature) =>
        {
            var result = await deleteCategoryFeature.DeleteAsync(id);

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