using Confluent.Kafka;
using Kafka.Core.Interfaces;

namespace Kafka.Core.Services
{
	public class KafkaEventBus : IEventBus
    {
		public KafkaEventBus()
		{

		}

		public async Task Notify<T>(string channel, T eventPayload, Headers headers)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteMessage(string channel, Message<byte[], byte[]> message)
		{
            throw new NotImplementedException();
        }
    }
}

