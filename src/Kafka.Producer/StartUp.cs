using Kafka.Common.Extensions;
using Kafka.Core;
using Kafka.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Producer
{
	public class StartUp
	{
		private static IServiceCollection? _serviceCollection;

        public static IServiceCollection Container => _serviceCollection ??= ConfigureServices(ReadConfiguration());

        public static IServiceProvider? ServiceProvider;

        public static IServiceProvider BuildServiceProvider()
        {
            ServiceProvider = Container.BuildServiceProvider();
            return ServiceProvider;
        }

		private static IServiceCollection ConfigureServices(IConfigurationRoot configuration)
		{
			var services = new ServiceCollection();

            services.AddSingleton<IConfigurationRoot>(configuration);
            services.RegisterCommonServices();
            services.RegisterHostServices();
            services.RegisterCoreServices();

            return services;
        }

		private static IConfigurationRoot ReadConfiguration()
		{
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();
            var configuration = builder.Build();
            return configuration;
        }
	}
}

