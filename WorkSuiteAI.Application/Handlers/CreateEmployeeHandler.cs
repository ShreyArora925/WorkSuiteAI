using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.Commands;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Infrastructure.Data;
using WorkSuiteAI.Domain.Entities;  

namespace WorkSuiteAI.Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IRepository<Employee> _repository;

        public CreateEmployeeHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Department = request.Department,
                HourlyRate = request.HourlyRate,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.Add(employee);

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

    }
}
