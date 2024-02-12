namespace Kafka.Core
{
	internal class KeyStore
	{
		public static class ConfigurationKeys
		{
			public const string KafkaSettings = "kafka_settings";
		}

        public static class LogMessages
        {
            public const string InitializationSuccess = "Initialized consumer and subscribed to topic '{0}' successfully";
            public const string PublishSuccess = "Message published successfully | Delivery report: '{0}'";
            public const string TombstoneSuccess = "Message with key '{message.Headers.GetLastBytes(\"message-key\")}' marked for deletion | Delivery report: '{0}'";
            public const string DisposeConsumerSuccess = "Disposed message successfully";
        }

        public static class MessageAttributes
        {
            public const string Key = "id";
        }
    }
}

