using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ProfitDistribution.Api.App.Models;

namespace ProfitDistribution.Api.App.Database
{
    public class InMemoryDataContext : DbContext
    {
        public InMemoryDataContext(DbContextOptions<InMemoryDataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var employees = JArray.Parse(File.ReadAllText("storage/employee.json"));
            foreach (var employee in employees)
            {
                modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Registration = employee["matricula"].ToString(),
                        Name = employee["nome"].ToString(),
                        Area = employee["area"].ToString(),
                        Role = employee["cargo"].ToString(),
                        Salary = (int)(float.Parse(employee["salario_bruto"].ToString().Replace("R$ ", "").Replace(".", "").Replace(",", ".")) * 100),
                        AdmissionAt = DateTime.ParseExact(employee["data_de_admissao"].ToString(), "yyyy-MM-dd", null)
                    }
                ); ;
            }
        }
    }
}
