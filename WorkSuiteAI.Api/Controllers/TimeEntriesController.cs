


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
        public async Task<IActionResult> GetById(int id) => Ok(await _timeEntryService.GetById(id));

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _timeEntryService.GetAll());

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId(int employeeId) => Ok(await _timeEntryService.GetByEmployeeId(employeeId));

        [HttpPost("clockin")]
        public async Task<IActionResult> ClockIn(CreateTimeEntryRequest request) => Ok(await _timeEntryService.ClockIn(request));

        [HttpPost("clockout")]
        public async Task<IActionResult> ClockOut(ClockOutRequest request ) => Ok(await _timeEntryService.ClockOut(request));

    }
}
