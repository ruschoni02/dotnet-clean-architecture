using System;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence
{
    public class AdmissionAtCalculator : CalculatorGateway
    {
        private DateTime EightYears = DateTime.Now.AddYears(8);
        private DateTime ThreeYears = DateTime.Now.AddYears(3);
        private DateTime OneYear = DateTime.Now.AddYears(1);

        public int Calculate(Employee employee)
        {
            if (EightYears > employee.AdmissionAt)
            {
                return 5;
            }

            if (ThreeYears > employee.AdmissionAt)
            {
                return 3;
            }

            if (OneYear > employee.AdmissionAt)
            {
                return 2;
            }

            return 1;
        }
    }
}
