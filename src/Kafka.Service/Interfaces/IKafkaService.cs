namespace Kafka.Service.Interfaces
{
	public interface IKafkaService
	{
        Task PublishAsync<T>(T eventPayload);

        Task<T> ConsumeAsync<T>();
    }
}

