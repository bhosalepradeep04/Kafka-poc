using Microsoft.Extensions.Configuration;

namespace Kafka.Common.Configuration
{
	public class ConfigurationProvider : Interfaces.IConfigurationProvider
    {
        private readonly IConfigurationRoot _configuration;

        public ConfigurationProvider(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetValue(string key)
        {
            var section = _configuration.GetSection(key);
            if (section == default)
                throw new KeyNotFoundException(key);

            return section.Value;
        }

        public async Task<T> GetValue<T>(string key) where T : new()
        {
            var section = _configuration.GetSection(key);
            if (section == default)
                throw new KeyNotFoundException(key);

            var value = new T();
            section.Bind(value);

            return value;
        }
    }
}

