using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence
{
    public interface CalculatorGateway
    {
        public int Calculate(Employee employee);
    }
}
