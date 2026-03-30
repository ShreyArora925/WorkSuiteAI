using Microsoft.Identity.Client;
using NSubstitute;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Services;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Infrastructure.Data;

namespace WorkSuiteAI.Tests
{
    public class EmployeeServiceTests
    {

        private readonly IRepository<Employee> _mockRepo;
        private readonly EmployeeService _employeeService;
        public EmployeeServiceTests()
        {
            _mockRepo = NSubstitute.Substitute.For<IRepository<Employee>>();
            _employeeService = new EmployeeService(_mockRepo);

        }

        [Fact]
        public async Task CreateEmployee_ValidRequest_ReturnsCorrectResponse()
        {

            //Arrange
            var request = new CreateEmployeeRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@test.com",
                Department = "Engineering",
                HourlyRate = 45.00m
            };

            //Act
            var result = await _employeeService.CreateEmployee(request);

            //Assert 
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
        }

        [Fact]
        public async Task GetEmployeeById_ExistingEmployee_ReturnsCorrectResponse()
        {

            var employees = new List<Employee>
            {
                new Employee { Id=1, FirstName="John", LastName="Doe",
                      Email="john@test.com", Department="Engineering", HourlyRate=45 }
            };

            _mockRepo.GetAll().Returns(employees);

            var result = await _employeeService.GetAllEmployees();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count()); // verify count too

        }

        [Fact]
        public async Task GetEmployeeById_NonExistingEmployee_ReturnsNull()
        {
            //Arrange
            int empId = 999;

            // Act
            var result = await _employeeService.GetEmployeeById(empId);

            // Assert

            Assert.Null(result);
        }
    }
}
