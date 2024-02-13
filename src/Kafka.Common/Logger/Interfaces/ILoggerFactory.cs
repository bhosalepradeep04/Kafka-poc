using Kafka.Common.Interfaces;
using Kafka.Common.Models.Enums;

namespace Kafka.Common.Logger.Interfaces
{
	public interface ILoggerFactory
	{
		IAppLogger GetLogger(SupportedLoggers loggerName);
	}
}

