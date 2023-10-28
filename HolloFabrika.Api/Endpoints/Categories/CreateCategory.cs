using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Request;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Api.Validators.Filters;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Endpoints.Categories;

public class CreateCategory : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Categories.Create, async (
            CreateCategoryRequest categoryRequest,
            CreateCategoryFeature createCategoryFeature
        ) =>
        {
            var category = new Category
            {
                Name = categoryRequest.Name
            };

            var result = await createCategoryFeature.CreateAsync(category);

            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

            return Results.Ok(new CategoryResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Attributes = new List<AttributeResponse>(),
            });
        }).AddEndpointFilter<ValidationFilter<CreateCategoryRequest>>();
    }
}