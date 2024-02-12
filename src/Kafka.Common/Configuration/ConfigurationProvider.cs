using Kafka.Common.Interfaces;

namespace Kafka.Common.Configuration
{
	public class ConfigurationProvider : IConfigurationProvider
    {
        public Task<T> GetValue<T>(string key)
        {
            throw new NotImplementedException();
        }
    }
}

