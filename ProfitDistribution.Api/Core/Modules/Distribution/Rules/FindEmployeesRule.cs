using System;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;
using System.Collections.Generic;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;

namespace ProfitDistribution.Api.Core.Modules.Distribution.Rules
{
    public class FindEmployeesRule
    {
        private EmployeeGateway _employeeGateway;

        public FindEmployeesRule(EmployeeGateway employeeGateway)
        {
            _employeeGateway = employeeGateway;
        }

        public List<Employee> Execute()
        {
            try
            {
                return _employeeGateway.List();
            }
            catch (Exception exception)
            {
                throw new FindEmployeeException(exception);
            }
        }
    }
}
