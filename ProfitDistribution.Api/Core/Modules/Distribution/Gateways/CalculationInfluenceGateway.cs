using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Gateways
{
    public interface CalculationInfluenceGateway
    {
        public CalculationInfluence GetCalculationInfluence(Employee employee);
    }
}
