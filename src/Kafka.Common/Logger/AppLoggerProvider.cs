using Kafka.Common.Interfaces;

namespace Kafka.Common.Logger
{
	public class AppLoggerProvider : IAppLoggerProvider
    {
		private readonly IServiceProvider _serviceProvider;

		public AppLoggerProvider(IServiceProvider serviceProvider)
		{
            _serviceProvider = serviceProvider;
		}

        public Task<IAppLogger> GetAppLogger(string loggerName)
        {
            switch (loggerName)
            {
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}

