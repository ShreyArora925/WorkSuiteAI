using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WorkSuiteAI.Application.DTO;
using MediatR;

namespace WorkSuiteAI.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
