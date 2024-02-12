namespace Kafka.Common.Interfaces
{
	public interface IAppLogger
	{
		Task LogAsync(string message);

		Task LogAsync(Exception ex);
	}
}

