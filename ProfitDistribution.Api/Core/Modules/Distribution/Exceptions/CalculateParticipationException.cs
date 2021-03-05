namespace ProfitDistribution.Api.Core.Modules.Distribution.Exceptions
{
    public class CalculateParticipationException : System.Exception
    {
        public CalculateParticipationException(System.Exception exception) : base("Error to calculate participation", exception)
        {
        }
    }
}
