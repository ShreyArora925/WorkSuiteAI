


using Microsoft.AspNetCore.Mvc;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;

namespace WorkSuiteAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeEntriesController : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService;
        public TimeEntriesController(ITimeEntryService timeEntryService) 
        {
            _timeEntryService = timeEntryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_timeEntryService.GetById(id));

        [HttpGet]
        public IActionResult GetAll() => Ok(_timeEntryService.GetAll());

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetByEmployeeId(int employeeId) => Ok(_timeEntryService.GetByEmployeeId(employeeId));

        [HttpPost("clockin")]
        public IActionResult ClockIn(CreateTimeEntryRequest request) => Ok(_timeEntryService.ClockIn(request));

        [HttpPost("clockout")]
        public IActionResult ClockOut(ClockOutRequest request ) => Ok(_timeEntryService.ClockOut(request));

    }
}
