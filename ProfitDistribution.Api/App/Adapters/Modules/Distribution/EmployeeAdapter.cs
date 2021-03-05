using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfitDistribution.Api.App.Database;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;

namespace ProfitDistribution.Api.App.Adapters.Modules.Distribution
{
    public class EmployeeAdapter : EmployeeGateway
    {
        private InMemoryDataContext _database;

        public EmployeeAdapter(InMemoryDataContext database)
        {
            _database = database;
        }

        public List<Employee> List()
        {
            return ListAsync().Result;
        }

        public async Task<List<Employee>> ListAsync()
        {
            var employees = new List<Employee>();
            var models = await _database.Employees.ToListAsync();
            foreach (var model in models)
            {
                var employee = new Employee(
                    model.Registration,
                    model.Name,
                    model.Area,
                    model.Role,
                    model.Salary,
                    model.AdmissionAt
                );
                employees.Add(employee);
            }

            return employees;
        }
    }
}
