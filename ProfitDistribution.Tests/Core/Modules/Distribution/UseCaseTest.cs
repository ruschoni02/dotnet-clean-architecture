using Xunit;
using System;
using NSubstitute;
using System.Collections.Generic;
using ProfitDistribution.Api.Core.Modules.Distribution;
using ProfitDistribution.Api.Core.Dependencies.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Entities;
using ProfitDistribution.Api.Core.Modules.Distribution.Gateways;
using ProfitDistribution.Api.Core.Modules.Distribution.Exceptions;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution;
using ProfitDistribution.Api.App.Adapters.Modules.Distribution.CalculationInfluence;

namespace ProfitDistribution.Tests.Core.Modules.Distribution
{
    public class UseCaseTest
    {
        private LoggerGateway _loggerGatewayMock;
        private EmployeeGateway _employeeGatewayMock;
        private CalculationInfluenceGateway _calculationInfluenceGateway;

        public UseCaseTest()
        {
            _loggerGatewayMock = Substitute.For<LoggerGateway>();
            _employeeGatewayMock = Substitute.For<EmployeeGateway>();
            _calculationInfluenceGateway = new CalculationInfluenceAdapter(
                new AreaCalculator(),
                new SalaryCalculator(),
                new AdmissionAtCalculator()
            );
        }

        [Fact]
        public void TestShoulReturnOneParticipation()
        {
            var employee = Stubs.ValidEmployee();
            var request = Stubs.ValidRequest();
            _employeeGatewayMock.List().Returns(new List<Employee>() { employee });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            var response = useCase.Execute(request);

            Assert.Equal(18282528, response.Distribution.TotalDistributed);
            Assert.Same(employee, response.Distribution.Participations[0].Employee);
            Assert.Equal(request.AvailableValue, response.Distribution.TotalAvailable);
        }

        [Fact]
        public void TestShoulReturnTwoParticipations()
        {
            var employee = Stubs.ValidEmployee();
            var request = Stubs.ValidRequest();
            _employeeGatewayMock.List().Returns(new List<Employee>() { employee, employee });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            var response = useCase.Execute(request);

            var participations = response.Distribution.Participations;
            Assert.Equal(36565056, response.Distribution.TotalDistributed);
            Assert.Same(employee, participations[0].Employee);
            Assert.Equal(request.AvailableValue, response.Distribution.TotalAvailable);
            Assert.Equal(2, participations.Count);
        }

        [Fact]
        public void TestShouldReturnInsufficientAvailableValueException()
        {
            _employeeGatewayMock.List().Returns(new List<Employee>() { Stubs.ValidEmployee() });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            Assert.Throws<InsufficientAvailableValueException>(() => useCase.Execute(new Request(50)));
        }

        [Fact]
        public void TestShouldReturnCalculateParticipationException()
        {
            var employee = Stubs.ValidEmployee();
            _employeeGatewayMock.List().Returns(new List<Employee>() { employee });
            var calculationInfluenceGatewayMock = Substitute.For<CalculationInfluenceGateway>();
            calculationInfluenceGatewayMock.GetCalculationInfluence(employee).Returns(new CalculationInfluence(1, 0, 5));

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                calculationInfluenceGatewayMock
            );

            Assert.Throws<CalculateParticipationException>(() => useCase.Execute(Stubs.ValidRequest()));
        }

        [Fact]
        public void TestShouldReturnCalculationInfluenceAreaNotFoundException()
        {
            _employeeGatewayMock.List().Returns(new List<Employee>() { Stubs.EmployeeWithInvalidArea() });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            Assert.Throws<CalculationInfluenceAreaNotFoundException>(() => useCase.Execute(Stubs.ValidRequest()));
        }

        [Fact]
        public void TestShouldReturnFindEmployeeException()
        {
            _employeeGatewayMock.List().Returns(x => { throw new Exception(); });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            Assert.Throws<FindEmployeeException>(() => useCase.Execute(Stubs.ValidRequest()));
        }

        [Fact]
        public void TestShouldReturnGetCalculationInfluenceException()
        {
            var employee = Stubs.ValidEmployee();
            _employeeGatewayMock.List().Returns(new List<Employee>() { employee });
            var calculationInfluenceGatewayMock = Substitute.For<CalculationInfluenceGateway>();
            calculationInfluenceGatewayMock.GetCalculationInfluence(employee).Returns(x => { throw new Exception(); });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                calculationInfluenceGatewayMock
            );

            Assert.Throws<GetCalculationInfluenceException>(() => useCase.Execute(Stubs.ValidRequest()));
        }

        [Fact]
        public void TestShouldReturnGenericException()
        {
            _employeeGatewayMock.List().Returns(new List<Employee>() { Stubs.ValidEmployee() });
            _loggerGatewayMock.When(fake => fake.Info(Arg.Any<string>())).Do(call => { throw new Exception("Generic exception"); });

            var useCase = new UseCase(
                _loggerGatewayMock,
                _employeeGatewayMock,
                _calculationInfluenceGateway
            );

            Assert.Throws<Exception>(() => useCase.Execute(Stubs.ValidRequest()));
        }
    }
}
