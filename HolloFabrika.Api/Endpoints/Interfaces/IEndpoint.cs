namespace HolloFabrika.Api.Endpoints.Interfaces;

public interface IEndpoint
{
    static abstract void DefineEndpoint(IEndpointRouteBuilder app);
}