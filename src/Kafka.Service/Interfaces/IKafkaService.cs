namespace Kafka.Service.Interfaces
{
	public interface IKafkaService
	{
        Task PublishAsync<T>(T eventPayload);

        Task ConsumeAsync<T>();
    }
}

