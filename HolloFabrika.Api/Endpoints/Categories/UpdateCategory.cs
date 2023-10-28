using FluentValidation;
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

public class UpdateCategory : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoutes.Categories.Update, async (
            string id,
            UpdateCategoryRequest categoryRequest,
            UpdateCategoryFeature updateCategoryFeature
        ) =>
        {
            var category = new Category
            {
                Id = Guid.Parse(id),
                Name = categoryRequest.Name
            };

            var result = await updateCategoryFeature.UpdateAsync(category);

            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

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
        }).AddEndpointFilter<ValidationFilter<UpdateCategoryRequest>>();
    }
}