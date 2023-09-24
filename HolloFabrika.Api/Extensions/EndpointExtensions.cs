using System.Reflection;
using HolloFabrika.Api.Endpoints.Interfaces;

namespace HolloFabrika.Api.Extensions;

public static class EndpointExtensions
{
    public static void UseEndpoints(this IApplicationBuilder app)
    {
        var endpointTypes = GetEndpointsTypesFromAssemblyContaining(typeof(IEndpoint));

        foreach (var endpointType in endpointTypes)
        {
            endpointType.GetMethod(nameof(IEndpoint.DefineEndpoint))!.Invoke(null, new object[] { app });
        }
    }

    private static IEnumerable<TypeInfo> GetEndpointsTypesFromAssemblyContaining(Type typeMarker)
    {
        return typeMarker.Assembly.DefinedTypes.Where(
            x => x is { IsAbstract: false, IsInterface: false } && x.IsAssignableTo(typeof(IEndpoint))
        );
    }
}