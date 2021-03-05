namespace ProfitDistribution.Api.Core.Modules.Distribution.Exceptions
{
    public class FindEmployeeException : System.Exception
    {
        public FindEmployeeException(System.Exception exception) : base("Error to find employees", exception)
        {
        }
    }
}
