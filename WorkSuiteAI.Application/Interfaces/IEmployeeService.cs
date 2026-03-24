using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllEmployees();
        Task<EmployeeResponse> GetEmployeeById(int id);
        Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
