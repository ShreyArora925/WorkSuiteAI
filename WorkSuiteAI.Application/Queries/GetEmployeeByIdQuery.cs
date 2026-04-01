using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WorkSuiteAI.Application.DTO;
namespace WorkSuiteAI.Application.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public int Id { get; set; }
    }
}
