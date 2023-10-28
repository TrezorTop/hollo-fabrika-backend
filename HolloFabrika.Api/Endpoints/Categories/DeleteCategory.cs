using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Endpoints.Categories;

public class DeleteCategory : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoutes.Categories.Delete, async (string id, DeleteCategoryFeature deleteCategoryFeature) =>
        {
            var result = await deleteCategoryFeature.DeleteAsync(id);

            if (result.IsFailed) return Results.NotFound(result.ToErrorResponse());

            return Results.Ok(new CategoryResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Attributes = result.Value.Attributes.Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = result.Value.Id,
                }).ToList(),
            });
        });
    }
}