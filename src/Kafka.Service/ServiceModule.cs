using Kafka.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Service
{
	public static class ServiceModule
	{
        public static IServiceCollection RegisterHostServices(this IServiceCollection services)
        {
            services.AddTransient<IKafkaService, KafkaService>();
            return services;
        }
    }
}

