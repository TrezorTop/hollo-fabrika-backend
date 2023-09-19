using HolloFabrika.Feature.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HolloFabrika.Feature;

public static class ServicesExtensions
{
    public static void AddFeatures(this IServiceCollection serviceCollection)
    {
        var featureTypes = typeof(ServicesExtensions).Assembly.GetTypes()
            .Where(type =>
                type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IFeatureMarker))
            )
            .ToArray();

        
        foreach (var featureType in featureTypes)
        {
            serviceCollection.AddScoped(featureType);
        }
    }
}