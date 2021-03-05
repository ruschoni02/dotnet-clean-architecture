using System.Collections.Generic;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Gateways
{
    public interface EmployeeGateway
    {
        public List<Employee> List();
    }
}
