namespace ProfitDistribution.Api.Core.Dependencies.Gateways
{
    public interface LoggerGateway
    {
        public void Info(string message);

        public void Error(string message);

        public void Debug(string message);
    }
}
