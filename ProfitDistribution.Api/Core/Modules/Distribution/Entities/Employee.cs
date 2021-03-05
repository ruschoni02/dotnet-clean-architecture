using System;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Entities
{
    public class Employee
    {
        public Employee(string registration, string name, string area, string role, int salary, DateTime admissionAt)
        {
            this.Registration = registration;
            this.Name = name;
            this.Area = area;
            this.Role = role;
            this.Salary = salary;
            this.AdmissionAt = admissionAt;
        }

        public string Registration { get; }

        public string Name { get; }

        public string Area { get; }

        public string Role { get; }

        public int Salary { get; }

        public System.DateTime AdmissionAt { get; }
    }
}
