namespace Kafka.Core.Models
{
	public class KafkaConfiguration
	{
		public string? TopicName { get; set; }

		public List<KafkaBroker> Brokers { get; set; } = new List<KafkaBroker>();

		public string? ServerEndpoints => string.Join(",", Brokers);
	}
}

