namespace Kafka.Common.Interfaces
{
	public interface IConfigurationProvider
	{
		Task<T> GetValue<T>(string key);
	}
}

