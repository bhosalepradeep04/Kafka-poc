using Microsoft.Extensions.Hosting;

namespace Kafka.Producer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IHostEnvironment environment = hostContext.HostingEnvironment;
                    services.RegisterServices(environment);
                })
                .Build();

            await host.RunAsync();
        }
    }
}