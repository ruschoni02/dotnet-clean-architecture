namespace ProfitDistribution.Api.Core.Modules.Distribution
{
    public class Request
    {
        public Request(long availableValue)
        {
            this.AvailableValue = availableValue;
        }

        public long AvailableValue { get; }
    }
}
