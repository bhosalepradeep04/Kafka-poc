using Kafka.Common.Models.Enums;

namespace Kafka.Common.Interfaces
{
	public interface IAppLoggerProvider
	{
		Task<IAppLogger> GetAppLogger(SupportedLoggers loggerName);
	}
}

