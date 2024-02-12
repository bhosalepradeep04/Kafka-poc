namespace Kafka.Service
{
	internal class KeyStore
	{
		public static class ConfigurationKeys
		{
			public const string TopicName = "TopicName";
		}

        public static class LogMessages
        {
            public const string HandlerSuccess = "Consume message handler invoked successfully | Payload: '{0}'";
        }

        public static class MessageAttributes
        {
            public const string Key = "id";
            public const string Epoch = "message-epoch";
        }
    }
}

