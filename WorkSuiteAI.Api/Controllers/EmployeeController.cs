using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WorkSuiteAI.Application.Commands;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Queries;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Domain.Interfaces;

namespace WorkSuiteAI.Api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMediator _mediator;   

        public EmployeesController(IEmployeeService employeeService, IMediator mediator)
        {
            _employeeService = employeeService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var employees = await _employeeService.GetAllEmployees();
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id});
                //await _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequest request)
        {
            var created = await _mediator.Send(new CreateEmployeeCommand { Department = request.Department ,
            Email = request.Email , FirstName = request.FirstName , LastName = request.LastName , HourlyRate = request.HourlyRate});
                //await _employeeService.CreateEmployee(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            await _employeeService.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }
    }
}
