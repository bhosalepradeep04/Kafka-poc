using Kafka.Common.Extensions;
using Kafka.Core;
using Kafka.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kafka.Producer
{
	public static class Module
	{
		internal static void RegisterServices(this IServiceCollection services, IHostEnvironment environment)
		{
			var builder = new ConfigurationBuilder()
							.SetBasePath(environment.ContentRootPath)
							.AddJsonFile("appsettings.json")
							.AddEnvironmentVariables();
			var configuration = builder.Build();
			services.AddSingleton<IConfiguration>(configuration);
            services.RegisterCommonServices();
            services.RegisterHostServices();
			services.RegisterCoreServices();
		}
	}
}

