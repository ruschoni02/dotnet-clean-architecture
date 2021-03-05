using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution
{
    public class CalculationInfluenceAdapter : CalculationInfluenceGateway
    {
        private CalculatorGateway _areaCalculator;
        private CalculatorGateway _salaryCalculator;
        private CalculatorGateway _admissionAtCalculator;

        public CalculationInfluenceAdapter(
            CalculatorGateway areaCalculator,
            CalculatorGateway salaryCalculator,
            CalculatorGateway admissionAtCalculator
        )
        {
            _areaCalculator = areaCalculator;
            _salaryCalculator = salaryCalculator;
            _admissionAtCalculator = admissionAtCalculator;
        }

        public Core.Modules.Distribution.Entities.CalculationInfluence GetCalculationInfluence(Employee employee)
        {
            return new Core.Modules.Distribution.Entities.CalculationInfluence(
                _areaCalculator.Calculate(employee),
                _salaryCalculator.Calculate(employee),
                _admissionAtCalculator.Calculate(employee)
            );
        }
    }
}
