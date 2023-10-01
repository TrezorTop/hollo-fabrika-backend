using FluentValidation;
using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Request;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Feature.Entities;
using HolloFabrika.Feature.Features.Categories;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Api.Endpoints.Categories;

public class Update : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoutes.Categories.Update, async (
            string id,
            UpdateCategoryRequest categoryRequest,
            UpdateCategoryFeature updateCategoryFeature,
            IValidator<UpdateCategoryRequest> validator
        ) =>
        {
            var validationResult = await validator.ValidateAsync(categoryRequest);
            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

            var category = new Category
            {
                Id = Guid.Parse(id),
                Name = categoryRequest.Name,
                Attributes = categoryRequest.Attributes.Select(x => new Attribute
                {
                    Id = x.Id, 
                    Name = x.Name,
                    CategoryId = categoryRequest.Id
                }).ToList()
            };

            var result = await updateCategoryFeature.UpdateAsync(category);

            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

            return Results.Ok(result.Value);
        });
    }
}