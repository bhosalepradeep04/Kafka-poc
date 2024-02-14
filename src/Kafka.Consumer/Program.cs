using Kafka.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Consumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                StartUp.BuildServiceProvider();
                using (var scope = StartUp.ServiceProvider?.CreateScope())
                {
                    await scope.ServiceProvider.GetRequiredService<IKafkaService>().PublishAsync<string>("Dummy event");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Producer exception: {ex}");
            }
        }
    }
}