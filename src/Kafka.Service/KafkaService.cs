using Kafka.Service.Interfaces;

namespace Kafka.Service;

public class KafkaService : IKafkaService
{
    public async Task PublishAsync<T>(T eventPayload)
    {
        throw new NotImplementedException();
    }

    public async Task<T> ConsumeAsync<T>()
    {
        throw new NotImplementedException();
    }
}
