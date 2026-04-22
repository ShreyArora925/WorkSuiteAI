using Microsoft.AspNetCore.Mvc;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;

namespace WorkSuiteAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobAgentController : ControllerBase
    {
        private readonly IJobAgentService _jobAgentService;

        public JobAgentController(IJobAgentService jobAgentService)
        {
            _jobAgentService = jobAgentService ?? throw new ArgumentNullException(nameof(jobAgentService));
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchJobs([FromBody] JobSearchRequest request) // ← FIXED: async, FromBody
        {
            try
            {
               
                var result = await _jobAgentService.ProcessJobSearchAsync(request);

              
                return Ok(new { success = true, data = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = "Failed to process job search", details = ex.Message });
            }
        }
    }
}
