using System;

namespace WorkSuiteAI.Application.DTO
{
    public record JobSearchRequest
    {
        public string Location { get; init; } = string.Empty;
        public string Keywords { get; init; } = string.Empty;
        public SalaryRange? Salary { get; init; }
        public string? ExperienceLevel { get; init; }
        public int MaxResults { get; init; } = 10;
        public int? PostedWithinDays { get; init; }
    }
}