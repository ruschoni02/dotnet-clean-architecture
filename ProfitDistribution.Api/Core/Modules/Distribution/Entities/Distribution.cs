using System.Collections.Generic;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Entities
{
    public class Distribution
    {
        public Distribution(long totalAvailable)
        {
            TotalAvailable = totalAvailable;
            Participations = new List<Participation>();
        }

        public List<Participation> Participations { get; set; }

        public int TotalDistributed { get; set; }

        public long TotalAvailable { get; }
    }
}
