using HolloFabrika.Api.Contracts;
using HolloFabrika.Api.Endpoints.Interfaces;

namespace HolloFabrika.Api.Endpoints.Attributes;

public class Create : IEndpoint
{
    public static void DefineEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Attributes.Create, async
        (
            
        ) =>
        {
        });
    }
}