using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;

namespace WorkSuiteAI.Application.Services
{
    public class JobSearchTool: IJobSearchTool
    {
        public Task<List<JobMatch>> SearchJobsAsync(JobSearchRequest request)
        {
            // Placeholder implementation - in a real application, this would call an external API
            var dummyJobs = GetMockJobPool();
            var results = dummyJobs.Take(request.MaxResults).ToList();

            return Task.FromResult(results);
        }

        private List<JobMatch> GetMockJobPool()
        {
            return new List<JobMatch>
            {
                // .NET Jobs
                new JobMatch
                {
                    Title = "Senior .NET Developer",
                    Company = "Microsoft Canada",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(90000, 120000),
                    JobUrl = "https://careers.microsoft.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-2)
                },
                new JobMatch
                {
                    Title = "Full-Stack .NET Developer",
                    Company = "RBC",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(85000, 110000),
                    JobUrl = "https://jobs.rbc.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-5)
                },
                new JobMatch
                {
                    Title = ".NET Backend Developer",
                    Company = "Shopify",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(95000, 130000),
                    JobUrl = "https://www.shopify.com/careers/...",
                    DatePosted = DateTime.UtcNow.AddDays(-1)
                },
                new JobMatch
                {
                    Title = "ASP.NET Core Developer",
                    Company = "TD Bank",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(80000, 105000),
                    JobUrl = "https://jobs.td.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-7)
                },
                new JobMatch
                {
                    Title = ".NET Software Engineer",
                    Company = "Cognizant Canada",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(75000, 95000),
                    JobUrl = "https://careers.cognizant.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-3)
                },
                
                // Other Tech Jobs (for filtering test)
                new JobMatch
                {
                    Title = "Senior Java Developer",
                    Company = "BMO",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(90000, 115000),
                    JobUrl = "https://jobs.bmo.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-4)
                },
                new JobMatch
                {
                    Title = "Python Backend Developer",
                    Company = "Amazon Canada",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(100000, 135000),
                    JobUrl = "https://www.amazon.jobs/...",
                    DatePosted = DateTime.UtcNow.AddDays(-6)
                },
                new JobMatch
                {
                    Title = "Full-Stack Developer (React + Node)",
                    Company = "Uber Canada",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(95000, 125000),
                    JobUrl = "https://www.uber.com/careers/...",
                    DatePosted = DateTime.UtcNow.AddDays(-8)
                },
                new JobMatch
                {
                    Title = ".NET Developer",
                    Company = "Rogers Communications",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(82000, 108000),
                    JobUrl = "https://jobs.rogers.com/...",
                    DatePosted = DateTime.UtcNow.AddDays(-10)
                },
                new JobMatch
                {
                    Title = "Software Developer - C# .NET",
                    Company = "Bell Canada",
                    Location = "Toronto, ON",
                    Salary = new SalaryRange(78000, 102000),
                    JobUrl = "https://jobs.bell.ca/...",
                    DatePosted = DateTime.UtcNow.AddDays(-12)
                }
            };
        }
    }     
}
