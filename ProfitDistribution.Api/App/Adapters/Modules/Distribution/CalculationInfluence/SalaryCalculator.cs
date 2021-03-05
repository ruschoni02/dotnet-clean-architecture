using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence
{
    public class SalaryCalculator : CalculatorGateway
    {
        private const int MINIMAL_SALARY = 110000;

        private const int MINIMAL_SALARY_8 = MINIMAL_SALARY * 8;
        private const int MINIMAL_SALARY_5 = MINIMAL_SALARY * 5;
        private const int MINIMAL_SALARY_3 = MINIMAL_SALARY * 3;

        public int Calculate(Employee employee)
        {
            if (MINIMAL_SALARY_8 > employee.Salary)
            {
                return 5;
            }

            if (MINIMAL_SALARY_5 > employee.Salary)
            {
                return 3;
            }

            if (MINIMAL_SALARY_3 > employee.Salary)
            {
                return 2;
            }

            return 1;
        }
    }
}
