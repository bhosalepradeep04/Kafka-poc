using Kafka.Common.Interfaces;

namespace Kafka.Common.Logger.Strategies
{
	public class ConsoleLoggerStrategy : IAppLogger
    {
        public async Task LogAsync(string message)
        {
            Console.WriteLine(message);
        }

        public async Task LogAsync(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}

