using Microsoft.Extensions.DependencyInjection;
using PSK.SmartGarden.Data.Repository;

namespace PSK.SmartGarden.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureData(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMeasurementRepository, MongoMeasurementRepository>();
        }
    }
}