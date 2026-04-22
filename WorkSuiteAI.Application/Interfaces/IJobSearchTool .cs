using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface IJobSearchTool
    {
        Task<List<JobMatch>> SearchJobsAsync(JobSearchRequest request);
    }
}
