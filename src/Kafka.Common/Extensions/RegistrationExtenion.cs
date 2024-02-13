using Kafka.Common.Configuration;
using Kafka.Common.Interfaces;
using Kafka.Common.Logger;
using Kafka.Common.Logger.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Common.Extensions
{
	public static class RegistrationExtenion
	{
		public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
		{
			services.AddSingleton<IConfigurationProvider, ConfigurationProvider>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton<IAppLoggerProvider, AppLoggerProvider>();

            return services;
		}
	}
}

