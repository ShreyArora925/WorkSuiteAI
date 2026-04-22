using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.DTO
{
    public record JobMatch
    {
        public string Title { get; init; } = string.Empty;
        public string Company { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty;
        public SalaryRange? Salary { get; init; }
        public string? JobUrl { get; init; }
        public DateTime? DatePosted { get; init; }


        public int MatchScore { get; set; }
        public string Recommendation { get; set; } = string.Empty;
        public string CoverLetter { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
