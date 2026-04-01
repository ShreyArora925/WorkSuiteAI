using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.Queries;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Infrastructure.Data;
using WorkSuiteAI.Domain.Entities;


namespace WorkSuiteAI.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IRepository<Employee> _queryrepo;
        public GetEmployeeByIdHandler(IRepository<Employee> repository) 
        { 
            _queryrepo = repository;
        }

        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _queryrepo.GetById(request.Id);
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
    }
}
