namespace ProfitDistribution.Api.Core.Modules.Distribution.Exceptions
{
    public class CalculationInfluenceAreaNotFoundException : System.Exception
    {
        public CalculationInfluenceAreaNotFoundException(string area) : base($"The area: {area} does not exist.")
        {
        }
    }
}
