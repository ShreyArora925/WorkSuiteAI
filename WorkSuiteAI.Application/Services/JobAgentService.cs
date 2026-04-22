using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.Interfaces;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Services
{
    public class JobAgentService : IJobAgentService
    {
        private readonly IJobSearchTool _jobSearchTool;
        private readonly IResumeAnalyzer _resumeAnalyzer;
        private readonly ICoverLetterGenerator _coverLetterGenerator;

        private const string MY_RESUME = @"
            SHREY ARORA
            Full-Stack .NET Developer
            
            EXPERIENCE:
            - 5.5 years of C#, ASP.NET Core development
            - L&T Infotech: eLogistics project for Otis Elevators
            - TCS: Aegon pension application
            
            SKILLS:
            - Backend: C#, ASP.NET Core, Entity Framework, SQL Server
            - Architecture: Clean Architecture, CQRS, MediatR, Repository Pattern
            - Frontend: React (learning), JavaScript, HTML, CSS
            - AI: Claude API integration, Prompt Engineering
            - Tools: Git, Azure DevOps, Docker
            
            EDUCATION:
            - Postgraduate in AI/ML and Cloud Computing
        ";

        public JobAgentService(
           IJobSearchTool jobSearchTool,
           IResumeAnalyzer resumeAnalyzer,
           ICoverLetterGenerator coverLetterGenerator)
        {
            _jobSearchTool = jobSearchTool ?? throw new ArgumentNullException(nameof(jobSearchTool));
            _resumeAnalyzer = resumeAnalyzer ?? throw new ArgumentNullException(nameof(resumeAnalyzer));
            _coverLetterGenerator = coverLetterGenerator ?? throw new ArgumentNullException(nameof(coverLetterGenerator));
        }

        public async Task<JobApplicationResult> ProcessJobSearchAsync(JobSearchRequest request)
        {
           
            var jobs = await _jobSearchTool.SearchJobsAsync(request);

            if (jobs == null || jobs.Count == 0)
            {
                return new JobApplicationResult
                {
                    Jobs = new List<JobMatch>(),
                    OverallRecommendation = "No jobs found matching your criteria.",
                    TotalJobsFound = 0,
                };

            }

            foreach (var job in jobs)
            {
                var opp = await _resumeAnalyzer.AnalyzeResumeAsync(job, MY_RESUME);
                job.MatchScore = opp.MatchScore;

                job.Recommendation = job.MatchScore switch
                {
                    >= 90 => "Excellent match - apply immediately!",
                    >= 75 => "Strong match - highly recommended",
                    >= 60 => "Good match - consider applying",
                    >= 50 => "Moderate match - review carefully",
                    _ => "Low match - may not be ideal"
                };

                job.Status = job.MatchScore >= 75 && job.MatchScore < 80 ? "Recommended" : job.MatchScore >= 80 ? "Apply" : "Skip";

                // fetch cover letter only for strong matches to save time
                if (job.MatchScore >= 75)
                {
                    job.CoverLetter = await _coverLetterGenerator.GenerateCoverLetterAsync(job, MY_RESUME);
                }
            }


            return new JobApplicationResult();
        }

    }
}
