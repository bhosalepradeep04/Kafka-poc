using Kafka.Common.Interfaces;
using Kafka.Common.Logger.Interfaces;
using Kafka.Common.Models.Enums;

namespace Kafka.Common.Logger
{
	public class AppLoggerProvider : IAppLoggerProvider
    {
		private readonly ILoggerFactory _loggerFactory;

		public AppLoggerProvider(ILoggerFactory loggerFactory)
		{
            _loggerFactory = loggerFactory;
		}

        public async Task<IAppLogger> GetAppLogger(SupportedLoggers loggerName)
        {
            IAppLogger appLogger = default;
            switch (loggerName)
            {
                case SupportedLoggers.ConsoleLogger:
                    appLogger = _loggerFactory.GetLogger(loggerName);
                    break;
                default:
                    appLogger = _loggerFactory.GetLogger(SupportedLoggers.ConsoleLogger);
                    break;
            }

            return appLogger;
        }
    }
}

