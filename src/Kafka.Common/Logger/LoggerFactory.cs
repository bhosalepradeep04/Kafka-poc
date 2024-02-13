using Kafka.Common.Interfaces;
using Kafka.Common.Logger.Interfaces;
using Kafka.Common.Logger.Strategies;
using Kafka.Common.Models.Enums;

namespace Kafka.Common.Logger
{
	public class LoggerFactory : ILoggerFactory
	{
		public LoggerFactory()
		{
		}

        public IAppLogger GetLogger(SupportedLoggers loggerName)
        {
            // TODO: Take from dependency container instead of using new
            return new ConsoleLoggerStrategy();
        }
    }
}

