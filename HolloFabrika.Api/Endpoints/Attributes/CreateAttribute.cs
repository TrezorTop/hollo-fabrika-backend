using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Contracts.Request;
using HolloFabrika.Api.Contracts.Response;
using HolloFabrika.Api.Endpoints.Interfaces;
using HolloFabrika.Api.Extensions;
using HolloFabrika.Api.Validators.Filters;
using HolloFabrika.Feature.Features.Attributes;
using Attribute = HolloFabrika.Feature.Entities.Attribute;

namespace HolloFabrika.Api.Endpoints.Attributes;

public class CreateAttribute : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Attributes.Create, async (
            CreateAttributeRequest attributeRequest,
            CreateAttributeFeature createAttributeFeature
        ) =>
        {
            var attribute = new Attribute
            {
                Name = attributeRequest.Name
            };

            var result = await createAttributeFeature.CreateAsync(attribute);
            
            if (result.IsFailed) return Results.BadRequest(result.ToErrorResponse());

            return Results.Ok(new AttributeResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                CategoryId = result.Value.CategoryId
            });
        }).AddEndpointFilter<ValidationFilter<CreateAttributeRequest>>();
    }
}