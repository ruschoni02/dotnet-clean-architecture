using Xunit;
using System;
using NSubstitute;
using System.Collections.Generic;
using ProfitDistribution.Api.Core.Modules.Distribution;
using ProfitDistribution.Api.Core.Dependencies.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;

namespace ProfitDistribution.Tests.Core.Modules.Distribution
{
    public class UseCaseTest
    {
        [Fact]
        public void TestShouldUseCaseReturnOneParticipation()
        {
            var employee = new Employee(
                "0009968",
                "Victor Wilson",
                "Diretoria",
                "Diretor Financeiro",
                1269620,
                DateTime.ParseExact("2012-01-05", "yyyy-MM-dd", null)
            );
            var totalAvailble = 400000000;
            var loggerGatewayMock = Substitute.For<LoggerGateway>();
            var employeeGatewayMock = Substitute.For<EmployeeGateway>();
            employeeGatewayMock.List().Returns(new List<Employee>(){employee});
            var calculationInfluenceGatewayMock = Substitute.For<CalculationInfluenceGateway>();
            calculationInfluenceGatewayMock.GetCalculationInfluence(employee).Returns(new CalculationInfluence(1, 5, 5));

            var useCase = new UseCase(
                loggerGatewayMock,
                employeeGatewayMock,
                calculationInfluenceGatewayMock
            );

            var response = useCase.Execute(new Request(totalAvailble));

            Assert.Equal(18282528, response.Distribution.TotalDistributed);
            Assert.Same(employee, response.Distribution.Participations[0].Employee);
            Assert.Equal(totalAvailble, response.Distribution.TotalAvailable);
        }
    }
}
