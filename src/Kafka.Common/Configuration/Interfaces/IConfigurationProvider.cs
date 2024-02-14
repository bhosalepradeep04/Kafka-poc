namespace Kafka.Common.Interfaces
{
	public interface IConfigurationProvider
    {
        Task<string> GetValue(string key);

        Task<T> GetValue<T>(string key) where T : new();
    }
}

