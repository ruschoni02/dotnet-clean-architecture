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

        void LoggerGateway.Debug(string message)
        {
            _logger.LogDebug(message);
        }

        void LoggerGateway.Error(string message)
        {
            _logger.LogError(message);
        }

        void LoggerGateway.Info(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
