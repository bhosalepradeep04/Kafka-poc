namespace Kafka.Common.Interfaces
{
	public interface IAppLoggerProvider
	{
		Task<IAppLogger> GetAppLogger(string loggerName);
	}
}

