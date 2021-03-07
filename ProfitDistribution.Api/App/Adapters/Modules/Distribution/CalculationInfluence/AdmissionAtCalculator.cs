using System;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence
{
    public class AdmissionAtCalculator : CalculatorGateway
    {
        private DateTime Today = DateTime.Now;

        public int Calculate(Employee employee)
        {
            if (Today > employee.AdmissionAt.AddYears(8))
            {
                return 5;
            }

            if (Today > employee.AdmissionAt.AddYears(3))
            {
                return 3;
            }

            if (Today > employee.AdmissionAt.AddYears(1))
            {
                return 2;
            }

            return 1;
        }
    }
}
