using FluentValidation;
using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Dto;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Categories;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Api.Endpoints.Categories;

public class Create : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Categories.Create, async (
            CategoryRequest categoryRequest,
            CreateCategoryFeature createCategoryFeature,
            IValidator<CategoryRequest> validator
        ) =>
        {
            var validationResult = await validator.ValidateAsync(categoryRequest);
            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
            
            var category = new Category
            {
                Name = categoryRequest.Name,
                Attributes = categoryRequest.Attributes!.Select(x => new Attribute
                {
                    Name = x.Name!
                }).ToList()
            };

            var result = await createCategoryFeature.CreateAsync(category);

            if (result.IsFailed) return Results.BadRequest(result.Reasons);

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