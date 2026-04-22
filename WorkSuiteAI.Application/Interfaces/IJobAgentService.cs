using System.Threading.Tasks;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    /// <summary>
    /// Main service that orchestrates job search, analysis, and application
    /// </summary>
    public interface IJobAgentService
    {
        Task<JobApplicationResult> ProcessJobSearchAsync(JobSearchRequest request);
    }
}