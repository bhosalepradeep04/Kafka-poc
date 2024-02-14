using Kafka.Common.Interfaces;
using Kafka.Common.Logger.Interfaces;
using Kafka.Common.Logger.Strategies;
using Kafka.Common.Models.Enums;

namespace Kafka.Common.Logger
{
	public class LoggerFactory : ILoggerFactory
	{
        public IAppLogger GetLogger(SupportedLoggers loggerName)
        {
            switch (loggerName)
            {
                case SupportedLoggers.ConsoleLogger:
                    return new ConsoleLoggerStrategy();
                default:
                    return new ConsoleLoggerStrategy();
            }
        }
    }
}

