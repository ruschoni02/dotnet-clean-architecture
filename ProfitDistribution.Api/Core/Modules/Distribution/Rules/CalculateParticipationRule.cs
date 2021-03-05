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
                var participation = employee.Salary * calculationInfluence.AdmissionAtInfluence;
                participation += employee.Salary * calculationInfluence.AreaInfluence;
                participation /= calculationInfluence.SalaryInfluence;
                participation *= 12;
                return new Participation(employee, participation);
            }
            catch (Exception exception)
            {
                throw new CalculateParticipationException(exception);
            }
        }
    }
}
