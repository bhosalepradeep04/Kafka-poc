using Kafka.Core.Interfaces;
using Kafka.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Core
{
	public static class CoreModule
	{
		public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
		{
			services.AddTransient<IEventBus, KafkaEventBus>();
			services.AddTransient<IEventListener, EventListener>();
			return services;
		}
	}
}

