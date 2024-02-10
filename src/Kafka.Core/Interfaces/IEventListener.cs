using Kafka.Core.Models;

namespace Kafka.Core.Interfaces
{
	public interface IEventListener
	{
		/// <summary>
		/// Initializes consumer and subscriber
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="kafkaConfiguration">Consumer kafka configuration</param>
		/// <param name="eventHandler">Handler to be invoked post consumption of an event</param>
		/// <returns></returns>
		Task Initialize<T>(KafkaConfiguration kafkaConfiguration, EventHandler<T> eventHandler);

		/// <summary>
		/// Invoke handler
		/// </summary>
		/// <param name="cancellationToken">Cancellation token</param>
		/// <returns></returns>
		Task InvokeHandler(CancellationToken cancellationToken);

		/// <summary>
		/// Unsubscribe and release all the resources used by consumer
		/// </summary>
		/// <returns></returns>
		Task Dispose();
	}
}

