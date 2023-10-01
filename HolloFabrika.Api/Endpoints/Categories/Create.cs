using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Request;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Api.Validators.Filters;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Categories;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Api.Endpoints.Categories;

public class Create : IEndpoint
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
                Name = categoryRequest.Name,
                Attributes = categoryRequest.Attributes.Select(x => new Attribute
                {
                    Name = x.Name
                }).ToList()
            };

            var result = await createCategoryFeature.CreateAsync(category);

            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

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
        }).AddEndpointFilter<ValidationFilter<CreateCategoryRequest>>();
    }
}