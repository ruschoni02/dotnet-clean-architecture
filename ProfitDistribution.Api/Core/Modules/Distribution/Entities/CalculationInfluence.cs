namespace ProfitDistribution.Api.Core.Modules.Distribution.Entities
{
    public class CalculationInfluence
    {
        public CalculationInfluence(int areaInfluence, int salaryInfluence, int admissionAtInfluence)
        {
            AreaInfluence = areaInfluence;
            SalaryInfluence = salaryInfluence;
            AdmissionAtInfluence = admissionAtInfluence;
        }

        public int AreaInfluence { get; set; }

        public int SalaryInfluence { get; set; }

        public int AdmissionAtInfluence { get; set; }
    }
}
