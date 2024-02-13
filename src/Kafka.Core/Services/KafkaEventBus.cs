using Confluent.Kafka;
using Kafka.Common.Interfaces;
using Kafka.Common.Logger;
using Kafka.Core.Interfaces;
using Kafka.Core.Models;
using Newtonsoft.Json;

namespace Kafka.Core.Services
{
	public class KafkaEventBus : IEventBus
    {
		private readonly KafkaConfiguration _kafkaConfiguration;
		private readonly IConfigurationProvider _configurationProvider;
		private readonly IAppLogger _appLogger;

		public KafkaEventBus(IConfigurationProvider configurationProvider, IAppLoggerProvider appLoggerProvider)
        {
            _appLogger = appLoggerProvider.GetAppLogger(Common.Models.Enums.SupportedLoggers.ConsoleLogger).GetAwaiter().GetResult();
            _configurationProvider = configurationProvider;
			_kafkaConfiguration = _configurationProvider.GetValue<KafkaConfiguration>(KeyStore.ConfigurationKeys.KafkaSettings).GetAwaiter().GetResult();
		}

		public async Task Notify<T>(string channel, T eventPayload, Headers headers)
		{
			try
			{
				// Serialize message
				var message = JsonConvert.SerializeObject(eventPayload);
				var payloadInBytes = System.Text.Encoding.UTF8.GetBytes(message);

				// Publush an event
				var producerConfig = GetProducerConfig();
				using (var producer = new ProducerBuilder<byte[], byte[]>(producerConfig).Build())
				{
					var deliveryReport = await producer.ProduceAsync(channel, new Message<byte[], byte[]>
					{
						Key = headers.GetLastBytes(KeyStore.MessageAttributes.Key),
						Value = payloadInBytes,
						Headers = headers
					});

                    await _appLogger.LogAsync(string.Format(KeyStore.LogMessages.PublishSuccess, JsonConvert.SerializeObject(deliveryReport)));
                }
			}
			catch (ProduceException<Null, byte[]> produceException)
			{
				await _appLogger.LogAsync(produceException);
			}
			catch (Exception ex)
            {
                await _appLogger.LogAsync(ex);
            }
		}

		public async Task DeleteMessage(string channel, Message<byte[], byte[]> message)
        {
            try
            {
                // Producing a message with same key and null payload is marked the message for deletion and will be deleted when next compaction cycle runs
                var producerConfig = GetProducerConfig();
				var tombstone = new Message<byte[], byte[]>
				{
					Key = message.Headers.GetLastBytes(KeyStore.MessageAttributes.Key),
					Value = null,
					Headers = message.Headers
				};

				using (var producer = new ProducerBuilder<byte[], byte[]>(producerConfig).Build())
				{
					var deliveryReport = await producer.ProduceAsync(channel, tombstone);

                    await _appLogger.LogAsync(string.Format(KeyStore.LogMessages.TombstoneSuccess, JsonConvert.SerializeObject(deliveryReport)));
                }
            }
            catch (ProduceException<Null, byte[]> produceException)
            {
                await _appLogger.LogAsync(produceException);
            }
            catch (Exception ex)
            {
                await _appLogger.LogAsync(ex);
            }
        }

		private ProducerConfig GetProducerConfig()
		{
			return new ProducerConfig()
			{
				BootstrapServers = _kafkaConfiguration.ServerEndpoints,
				SecurityProtocol = SecurityProtocol.Ssl,
				MessageTimeoutMs = 5000,
				RequestTimeoutMs = 1000
			};
		}
    }
}

