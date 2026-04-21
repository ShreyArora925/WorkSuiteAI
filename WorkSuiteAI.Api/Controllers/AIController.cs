using Microsoft.AspNetCore.Mvc;
using WorkSuiteAI.Application.AI.Interfaces;
using WorkSuiteAI.Application.Interfaces;

namespace WorkSuiteAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AIController(IAIService aiService)
        {
            _aiService = aiService ?? throw new ArgumentNullException(nameof(aiService));
        }

        [HttpPost("generate-review/{employeeId}")]
        public async Task<IActionResult> GenerateReview(int employeeId)
        {
            try
            {
                var review = await _aiService.GeneratePerformanceReviewAsync(employeeId); // ← FIXED: await
                return Ok(new { employeeId, review }); // Return structured response
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message }); // Employee not found
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to generate review", details = ex.Message });
            }
        }
    }
}
