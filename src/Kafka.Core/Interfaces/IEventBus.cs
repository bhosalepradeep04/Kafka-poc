using Confluent.Kafka;

namespace Kafka.Core.Interfaces
{
	public interface IEventBus
	{
		/// <summary>
		/// Raise event against specified channel
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="channel">Channel which will be used to raise an event</param>
		/// <param name="eventPayload">Payload which will be delivered to listeners of specified channels</param>
		/// <param name="headers">Headers which will be passed along with message</param>
		Task Notify<T>(string channel, T eventPayload, Headers headers);

		/// <summary>
		/// Tombstone - Deletes a message having same key from a specified channel when log compaction runs
		/// </summary>
		/// <param name="channel">Channel which will be used to raise an event</param>
		/// <param name="message">Message with null payload with same key</param>
		Task DeleteMessage(string channel, Message<byte[], byte[]> message);
	}
}

