namespace ProfitDistribution.Api.Core.Modules.Distribution.Entities
{
    public class Participation
    {
        public Participation(Employee employee, int value)
        {
            this.Employee = employee;
            this.Value = value;
        }

        public Employee Employee { get; set; }

        public int Value { get; set; }
    }
}
