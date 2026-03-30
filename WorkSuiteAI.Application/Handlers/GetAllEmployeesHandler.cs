using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.Services;
using WorkSuiteAI.Domain.Interfaces;
using WorkSuiteAI.Infrastructure.Data;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Application.Queries;

namespace WorkSuiteAI.Application.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {

        private readonly IRepository<Employee> _queryrepo;
        public GetAllEmployeesHandler(IRepository<Employee> _repo)
        {
            _queryrepo = _repo;
        }

        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _queryrepo.GetAll();
            return employees.Select(emp => new EmployeeResponse
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


    }
}
