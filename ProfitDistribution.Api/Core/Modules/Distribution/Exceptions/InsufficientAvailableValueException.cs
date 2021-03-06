namespace ProfitDistribution.Api.Core.Modules.Distribution.Exceptions
{
    public class InsufficientAvailableValueException : System.Exception
    {
        public InsufficientAvailableValueException() : base(" The available value is insufficient")
        {
        }
    }
}
