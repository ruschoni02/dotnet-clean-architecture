namespace ProfitDistribution.Api.Core.Modules.Distribution.Exceptions
{
    public class GetCalculationInfluenceException : System.Exception
    {
        public GetCalculationInfluenceException(System.Exception exception) : base("Error to get calculation influence", exception)
        {
        }
    }
}
