namespace ProfitDistribution.Api.Core.Modules.Distribution
{
    public class Response
    {
        public Response(Entities.Distribution distribution)
        {
            Distribution = distribution;
        }

        public Entities.Distribution Distribution { get; }
    }
}
