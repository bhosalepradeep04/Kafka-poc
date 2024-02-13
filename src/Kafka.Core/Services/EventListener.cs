using Confluent.Kafka;
using Kafka.Common.Interfaces;
using Kafka.Common.Logger;
using Kafka.Core.Interfaces;
using Kafka.Core.Models;
using Newtonsoft.Json;

namespace Kafka.Core.Services
{
	public class EventListener: IEventListener
    {
        private string _topicName;
        private KafkaConfiguration _kafkaConfiguration;
        private IConsumer<byte[], byte[]> _consumer;
        private EventHandler<object> _eventHandler;
        private readonly IAppLogger _appLogger;
        private readonly IConfigurationProvider _configurationProvider;

		public EventListener(IConfigurationProvider configurationProvider, IAppLoggerProvider appLoggerProvider)
        {
            _appLogger = appLoggerProvider.GetAppLogger(Common.Models.Enums.SupportedLoggers.ConsoleLogger).GetAwaiter().GetResult();
            _configurationProvider = configurationProvider;
            _kafkaConfiguration = _configurationProvider.GetValue<KafkaConfiguration>(KeyStore.ConfigurationKeys.KafkaSettings).GetAwaiter().GetResult();
        }

        public async Task Initialize<T>(string channel, KafkaConfiguration kafkaConfiguration, EventHandler<object> eventHandler)
        {
            _topicName = channel;
            _kafkaConfiguration = kafkaConfiguration;
            _consumer = new ConsumerBuilder<byte[], byte[]>(GetConsumerConfig()).Build();

            // Subscribe to topic
            _consumer.Subscribe(_topicName);

            // Initialize Handler
            _eventHandler = eventHandler;

            _appLogger.LogAsync(string.Format(KeyStore.LogMessages.InitializationSuccess, _topicName)).GetAwaiter().GetResult();
        }

        public async Task InvokeHandler(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult != null && consumeResult.Message != null)
                    {
                        // Validate cancellation token
                        if (cancellationToken.IsCancellationRequested)
                            cancellationToken.ThrowIfCancellationRequested();

                        // Deserialize message
                        var payloadInBytes = consumeResult.Message.Value;
                        var message = System.Text.Encoding.UTF8.GetString(payloadInBytes);
                        var eventBag = JsonConvert.DeserializeObject<object>(message);
                        if (eventBag != null)
                        {
                            // Invoke handler
                            _eventHandler(this, eventBag);

                            // Commit offset
                            _consumer.Commit(consumeResult);
                        }
                    }
                }
                catch (ConsumeException consumeException)
                {
                    await _appLogger.LogAsync(consumeException);
                }
                catch (Exception ex)
                {
                    await _appLogger.LogAsync(ex);
                }
            }
        }

        public async Task Dispose()
        {
            // Unsubscribe from the current set
            _consumer.Unsubscribe();

            // Commits offsets, alerts the group coordinator that the consumer is exiting the group, and then releases all the resoirses used by this consumer
            _consumer.Close();

            _consumer.Dispose();

            await _appLogger.LogAsync(KeyStore.LogMessages.DisposeConsumerSuccess);
        }

        private ConsumerConfig GetConsumerConfig()
        {
            return new ConsumerConfig()
            {
                BootstrapServers = _kafkaConfiguration.ServerEndpoints,
                SecurityProtocol = SecurityProtocol.Ssl,
                GroupId = $"{_topicName}_topic_consumer",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };
        }
    }
}

