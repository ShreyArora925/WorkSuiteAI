using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Domain.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetAllEmployees();
        EmployeeResponse GetEmployeeById(int id);
        EmployeeResponse CreateEmployee(CreateEmployeeRequest employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
