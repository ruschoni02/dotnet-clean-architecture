namespace ProfitDistribution.Api.Core.Dependencies.Gateways
{
    public interface LoggerGateway
    {
        public void Info(string message, object data = null);

        public void Error(string message, System.Exception exception);

        public void Debug(string message);
    }
}
