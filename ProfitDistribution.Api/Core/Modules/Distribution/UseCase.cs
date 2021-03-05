using ProfitDistribution.Api.Core.Dependencies.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Rules;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;

namespace ProfitDistribution.Api.Core.Modules.Distribution
{
    public class UseCase
    {
        private LoggerGateway _logger;
        private EmployeeGateway _employeeGateway;
        private CalculationInfluenceGateway _calculationInfluenceGateway;

        public UseCase(
            LoggerGateway logger,
            EmployeeGateway employeeGateway,
            CalculationInfluenceGateway calculationInfluenceGateway
        )
        {
            _logger = logger;
            _employeeGateway = employeeGateway;
            _calculationInfluenceGateway = calculationInfluenceGateway;
        }

        public Response Execute(Request request)
        {
            try
            {
                _logger.Info("Init distribution use case");
                var distribution = (new Ruleset(
                    new FindEmployeesRule(_employeeGateway),
                    new CalculationInfluenceRule(_calculationInfluenceGateway),
                    new CalculateParticipationRule()
                )).Execute(request);
                var response = new Response(distribution);
                _logger.Info("Finish distribution use case. {response}", response);
                return response;
            }
            catch (System.Exception exception)
            {
                _logger.Error("Error to execute distribution use case", exception);
                throw exception;
            }
        }
    }
}
