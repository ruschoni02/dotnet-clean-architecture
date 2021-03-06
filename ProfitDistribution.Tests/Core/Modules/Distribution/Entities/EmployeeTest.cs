using Xunit;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Tests.Core.Modules.Distribution.Entities
{
    public class EmployeeTest
    {
        [Fact]
        public void TestClassInstance()
        {
            var registration = "0001996";
            var name = "Vitor Ruschoni";
            var area = "Diretoria";
            var role = "Diretor Financeiro";
            var salary = 1269620;
            var admissionAt = System.DateTime.ParseExact("2012-01-05", "yyyy-MM-dd", null);
            var employee = new Employee(
                registration,
                name,
                area,
                role,
                salary,
                admissionAt
            );

            Assert.Same(registration, employee.Registration);
            Assert.Same(name, employee.Name);
            Assert.Same(area, employee.Area);
            Assert.Same(role, employee.Role);
            Assert.Equal(salary, employee.Salary);
            Assert.Equal(admissionAt, employee.AdmissionAt);
        }
    }
}