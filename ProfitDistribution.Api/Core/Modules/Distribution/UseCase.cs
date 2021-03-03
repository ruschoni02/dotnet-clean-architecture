using ProfitDistribution.Api.Core.Dependencies.Gateways;

namespace ProfitDistribution.Api.Core.Modules.Distribution
{
    public class UseCase
    {
        private LoggerGateway _logger;

        public UseCase(LoggerGateway logger)
        {
            _logger = logger;
        }

        public Response Execute(Request request)
        {
            try
            {
                _logger.Info("Init distribution use case");

                var response = new Response();

                _logger.Info("Finish distribution use case");
                return response;
            }
            catch (System.Exception exception)
            {
                _logger.Error("Error to execute distribution use case");
                throw exception;
            }
        }
    }
}
