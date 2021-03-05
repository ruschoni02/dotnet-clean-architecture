using System.Collections.Generic;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Entities
{
    public class Distribution
    {
        public Distribution(long totalAvailable)
        {
            TotalAvailable = totalAvailable;
        }

        public List<Participation> Participations { get; set; } = new List<Participation>();

        public int TotalDistributed { get; set; }

        public long TotalAvailable { get; }
    }
}
