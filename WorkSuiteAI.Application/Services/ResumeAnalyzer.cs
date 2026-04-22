using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WorkSuiteAI.Application.AI.Interfaces;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;

namespace WorkSuiteAI.Application.Services
{
    public class ResumeAnalyzer : IResumeAnalyzer
    {
        private readonly IClaudeClient _claudeClient;
        private readonly ILogger<ResumeAnalyzer> _logger;
        public ResumeAnalyzer(IClaudeClient claudeClient, ILogger<ResumeAnalyzer> logger)
        {
            _claudeClient = claudeClient ?? throw new ArgumentNullException(nameof(claudeClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<JobMatch> AnalyzeResumeAsync( JobMatch job , string resume)
        {
            _logger.LogInformation("Analyzing resume for job: {JobId}", job.Company);

            var prompt = BuildATSPrompt(job, resume);

            try
            {
                var response = await _claudeClient.SendPromptAsync(prompt);

                // Extract score from response
                var score =  response.Trim();

                _logger.LogInformation("Match score calculated: {Score} for {Title}", score, job.Title);

                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating match score for {Title} at {Company}", job.Title, job.Company);

                // Return neutral score on error
                return job;
            }


        }
        private string BuildATSPrompt(JobMatch job, string resume)
        {
            var salaryInfo = job.Salary != null
                ? $"${job.Salary.Min:N0} - ${job.Salary.Max:N0}"
                : "Not specified";

            return $@"
             You are an Applicant Tracking System (ATS) analyzing resume-job fit.
             
             JOB DESCRIPTION:
             Title: {job.Title}
             Company: {job.Company}
             Location: {job.Location}
             Salary Range: {salaryInfo}
             
             CANDIDATE RESUME:
             {resume}
             
             CANDIDATE CONSTRAINTS:
             - Open to relocation anywhere in Canada
             - Flexible on salary (minimum $80,000 CAD acceptable)
             - Priority: Getting the job and proving capabilities
             
             INSTRUCTIONS:
             Analyze the resume against the job description and provide a match score from 0-100.
             Focus ONLY on technical fit and experience - ignore location and salary.
             
             SCORING CRITERIA:
             - Technical Skills Match (50 points): How well do technical skills (languages, frameworks, tools) align?
               * Exact matches: Full points
               * Transferable skills (e.g., C# to Java): Partial points
               * Similar tech stack: Good points
               
             - Experience Level (30 points): Does experience level match job requirements?
               * Years of experience appropriate for role
               * Seniority level matches (junior/mid/senior)
               * Career progression shows growth
               
             - Domain/Industry Fit (20 points): Relevant project/industry experience?
               * Similar business domains (banking, logistics, etc.)
               * Relevant project types
               * Transferable domain knowledge
             
             SCORE RANGES:
             - 90-100: Exceptional match - perfect technical fit
             - 75-89: Strong match - highly qualified technically
             - 60-74: Good match - meets most technical requirements
             - 50-59: Moderate match - some technical gaps but trainable
             - 0-49: Poor match - significant technical mismatch
             
             IMPORTANT: 
             - Return ONLY the numeric score (0-100) as your response
             - Focus on TECHNICAL FIT and EXPERIENCE only
             - Do NOT penalize for location or salary
             - Consider learning ability and career trajectory
             - Value transferable skills highly
             
             Your response must be ONLY a number between 0 and 100. No explanation, just the score.
             
             SCORE:";
               
        }
    }
}
