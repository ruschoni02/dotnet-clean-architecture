using System;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Rules
{
    public class CalculateParticipationRule
    {
        public Participation Execute(Employee employee, CalculationInfluence calculationInfluence)
        {
            try
            {
                var salary = Math.Round(Convert.ToDecimal(employee.Salary), 5);
                var participation = salary * calculationInfluence.AdmissionAtInfluence;
                participation += salary * calculationInfluence.AreaInfluence;
                participation /= calculationInfluence.SalaryInfluence;
                participation *= 12;
                return new Participation(employee, (int)Math.Round(participation, 0));
            }
            catch (Exception exception)
            {
                throw new CalculateParticipationException(exception);
            }
        }
    }
}
