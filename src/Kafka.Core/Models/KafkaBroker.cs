using System.Text;

namespace Kafka.Core.Models
{
	public class KafkaBroker
	{
		public string? Host { get; set; }

		public string? Port { get; set; }

        public override string ToString()
        {
            var hostUrl = new StringBuilder();
            hostUrl.Append(Host);
            if (!string.IsNullOrWhiteSpace(Port))
                hostUrl.Append($":{Port}");

            return hostUrl.ToString();
        }
    }
}