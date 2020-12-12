using Microsoft.Extensions.DependencyInjection;

namespace PSK.SmartGarden.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMeasurementService, MeasurementService>();
        }
    }
}