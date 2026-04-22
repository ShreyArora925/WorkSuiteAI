using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.DTO
{
    public record JobApplicationResult
    {
        public List<JobMatch> Jobs { get; init; } = new();
        public string OverallRecommendation { get; init; } = string.Empty;
        public int TotalJobsFound { get; init; }
        public DateTime SearchedAt { get; init; } = DateTime.UtcNow;
    }

}
