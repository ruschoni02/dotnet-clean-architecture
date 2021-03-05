using System;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Rules
{
    public class CalculationInfluenceRule
    {
        private CalculationInfluenceGateway _calculationInfluenceGateway;

        public CalculationInfluenceRule(CalculationInfluenceGateway calculationInfluenceGateway)
        {
            _calculationInfluenceGateway = calculationInfluenceGateway;
        }

        public CalculationInfluence Execute(Employee employee)
        {
            try
            {
                return _calculationInfluenceGateway.GetCalculationInfluence(employee);
            }
            catch (Exception exception)
            {
                throw new GetCalculationInfluenceException(exception);
            }
        }
    }
}
