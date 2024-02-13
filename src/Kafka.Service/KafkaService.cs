using System.Text;
using Confluent.Kafka;
using Kafka.Common.Interfaces;
using Kafka.Core.Interfaces;
using Kafka.Service.Interfaces;
using Newtonsoft.Json;

namespace Kafka.Service;

public class KafkaService : IKafkaService
{
    private readonly IEventBus _eventBus;
    private readonly IEventListener _eventListener;
    private readonly IAppLogger _appLogger;
    private readonly IConfigurationProvider _configurationProvider;

    public KafkaService(IEventBus eventBus, IEventListener eventListener, IConfigurationProvider configurationProvider, IAppLoggerProvider appLoggerProvider)
    {
        _eventBus = eventBus;
        _eventListener = eventListener;
        _appLogger = appLoggerProvider.GetAppLogger(Common.Models.Enums.SupportedLoggers.ConsoleLogger).GetAwaiter().GetResult();
        _configurationProvider = configurationProvider;
    }

    public async Task PublishAsync<T>(T eventPayload)
    {
        var topicName = await _configurationProvider.GetValue<string>(KeyStore.ConfigurationKeys.TopicName);
        var dto = new DateTimeOffset(DateTime.UtcNow.AddMinutes(5).ToUniversalTime());
        var headers = new Headers
        {
            { KeyStore.MessageAttributes.Epoch, Encoding.UTF8.GetBytes(dto.ToUnixTimeMilliseconds().ToString()) },
            { KeyStore.MessageAttributes.Key, Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()) }
        };
        await _eventBus.Notify<T>(topicName, eventPayload, headers);
    }

    public async Task ConsumeAsync<T>()
    {
        // Initialize consumer and subscriber
        var topicName = await _configurationProvider.GetValue<string>(KeyStore.ConfigurationKeys.TopicName);
        await _eventListener.Initialize<T>(topicName, new Core.Models.KafkaConfiguration(), ConsumeMessageHandler);

        // Invoke handler
        await _eventListener.InvokeHandler(new CancellationToken());
    }

    public void ConsumeMessageHandler<T>(object sender, T eventPayload)
    {
        _appLogger.LogAsync(string.Format(KeyStore.LogMessages.HandlerSuccess, JsonConvert.SerializeObject(eventPayload))).GetAwaiter().GetResult();
    }
}
