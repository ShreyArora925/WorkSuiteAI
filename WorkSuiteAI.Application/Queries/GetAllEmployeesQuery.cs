using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;
using MediatR;

namespace WorkSuiteAI.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {

    }
}
