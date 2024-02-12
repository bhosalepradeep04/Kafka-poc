namespace Kafka.Core.Models
{
	public class KafkaConfiguration
	{
		public List<KafkaBroker> Brokers { get; set; } = new List<KafkaBroker>();

		public string? ServerEndpoints => string.Join(",", Brokers);
	}
}

