using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using ProfitDistribution.Api.Core.Dependencies.Gateways;

namespace ProfitDistribution.Api.App.Adapters
{
    public class LoggerAdapter : LoggerGateway
    {
        private ILogger _logger;

        public LoggerAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string message)
        {
            _logger.LogDebug(message);
        }

        public void Error(string message, System.Exception exception)
        {
            _logger.LogError(message + " {exception}", JsonConvert.SerializeObject(exception));
        }

        public void Info(string message, object data = null)
        {
            _logger.LogInformation(message, JsonConvert.SerializeObject(data));
        }
    }
}
