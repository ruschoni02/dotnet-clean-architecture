using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.App.Models
{
    public class Employee
    {
        [Key]
        public string Registration { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string Role { get; set; }

        public int Salary { get; set; }

        public System.DateTime AdmissionAt { get; set; }
    }
}
