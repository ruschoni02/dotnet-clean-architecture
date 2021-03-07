using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Rules
{
    public class Ruleset
    {
        private FindEmployeesRule _findEmployeesRule;
        private CalculationInfluenceRule _calculationInfluenceRule;
        private CalculateParticipationRule _calculateParticipationRule;

        public Ruleset(
            FindEmployeesRule findEmployeesRule,
            CalculationInfluenceRule calculationInfluenceRule,
            CalculateParticipationRule calculateParticipationRule
        )
        {
            _findEmployeesRule = findEmployeesRule;
            _calculationInfluenceRule = calculationInfluenceRule;
            _calculateParticipationRule = calculateParticipationRule;
        }

        public Entities.Distribution Execute(Request request)
        {
            var distribution = new Entities.Distribution(request.AvailableValue);
            var employees = _findEmployeesRule.Execute();
            foreach (var employee in employees)
            {
                var calculationInfluence = _calculationInfluenceRule.Execute(employee);
                var participation = _calculateParticipationRule.Execute(employee, calculationInfluence);
                distribution.Participations.Add(participation);
                distribution.TotalDistributed += participation.Value;

                if (distribution.TotalDistributed > request.AvailableValue)
                {
                    throw new InsufficientAvailableValueException();
                }
            }

            return distribution;
        }
    }
}
