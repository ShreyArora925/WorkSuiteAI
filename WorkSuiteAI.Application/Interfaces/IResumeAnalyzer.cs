using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface IResumeAnalyzer
    {
        public Task<JobMatch> AnalyzeResumeAsync(JobMatch jobMatches, string resume);
    }
}
