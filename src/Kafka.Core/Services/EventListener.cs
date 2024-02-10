using Kafka.Core.Interfaces;
using Kafka.Core.Models;

namespace Kafka.Core.Services
{
	public class EventListener : IEventListener
    {
		public EventListener()
		{
        }

        public async Task Initialize<T>(KafkaConfiguration kafkaConfiguration, EventHandler<T> eventHandler)
        {
            throw new NotImplementedException();
        }

        public async Task InvokeHandler(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

