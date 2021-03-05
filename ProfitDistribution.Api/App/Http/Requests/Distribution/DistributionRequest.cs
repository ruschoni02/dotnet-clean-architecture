using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.App.Http.Requests.Distribution
{
    public class DistributionRequest
    {
        [Range(1, long.MaxValue, ErrorMessage = "The available_value field cannot be null or less than 1")]
        [JsonPropertyName("available_value")]
        public long AvailableValue { get; set; }
    }
}
