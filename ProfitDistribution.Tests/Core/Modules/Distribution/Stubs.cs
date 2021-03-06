using ProfitDistribution.Api.Core.Modules.Distribution;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Tests.Core.Modules.Distribution
{
    public static class Stubs
    {
        public static Request ValidRequest()
        {
            return new Request(400000000);
        }
        public static Employee ValidEmployee()
        {
            return new Employee(
                "0001996",
                "Vitor Ruschoni",
                "Diretoria",
                "Diretor Financeiro",
                1269620,
                System.DateTime.ParseExact("2012-01-05", "yyyy-MM-dd", null)
            );
        }

        public static Employee EmployeeWithInvalidArea()
        {
            return new Employee(
                "0001996",
                "Vitor Ruschoni",
                "Presidente",
                "Diretor Financeiro",
                1269620,
                System.DateTime.ParseExact("2012-01-05", "yyyy-MM-dd", null)
            );
        }
    }
}