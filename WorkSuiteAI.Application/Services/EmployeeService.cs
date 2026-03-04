using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Domain.Interfaces;
using WorkSuiteAI.Infrastructure.Data;

namespace WorkSuiteAI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeResponse> GetAllEmployees()
        {
            var employee = _repository.GetAll();
            return employee.Select(emp => new EmployeeResponse
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Department = emp.Department,
                HourlyRate = emp.HourlyRate,
                CreatedAt = emp.CreatedAt
            });
        }

        public EmployeeResponse GetEmployeeById(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return null;

            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Department = employee.Department,
                HourlyRate = employee.HourlyRate,
                CreatedAt = employee.CreatedAt
            };
        }

        public EmployeeResponse CreateEmployee(CreateEmployeeRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Department = request.Department,
                HourlyRate = request.HourlyRate,
            };


            _repository.Add(employee);

            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Department = employee.Department,
                HourlyRate = employee.HourlyRate,
                CreatedAt = employee.CreatedAt
            }; 
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
