using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.Interfaces;
using WorkSuiteAI.Application.AI.Interfaces;
using Microsoft.Extensions.Logging;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Services
{
    public class CoverLetterGenerator : ICoverLetterGenerator
    {
        private readonly IClaudeClient _claudeClient;  
        private readonly ILogger<CoverLetterGenerator> _logger;
        
        public CoverLetterGenerator(IClaudeClient claudeClient, ILogger<CoverLetterGenerator> logger)
        {
            _claudeClient = claudeClient ?? throw new ArgumentNullException(nameof(claudeClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> GenerateCoverLetterAsync(JobMatch job, string resume)
        {
            _logger.LogInformation("Generating cover letter for job: {JobId}", job.Company);
            var prompt = BuildCoverLetterPrompt(job, resume);
            try
            {
                var response = await _claudeClient.SendPromptAsync(prompt);
                _logger.LogInformation("Cover letter generated successfully for {Title} at {Company}", job.Title, job.Company);
                return response.Trim();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating cover letter for {Title} at {Company}", job.Title, job.Company);
                return $"Unable to generate cover letter for {job.Title} at {job.Company} at this time. Please try again later.";
            }
        }

        private string BuildCoverLetterPrompt(JobMatch job, string resume)
        {
            var salaryInfo = job.Salary != null
                ? $"${job.Salary.Min:N0} - ${job.Salary.Max:N0}"
                : "Not specified";

            return $@"
             You are an expert career coach writing a professional cover letter for a software developer.
             
             JOB DETAILS:
             - Position: {job.Title}
             - Company: {job.Company}
             - Location: {job.Location}
             - Salary Range: {salaryInfo}
             
             CANDIDATE RESUME:
             {resume}
             
             INSTRUCTIONS:
             Write a professional, compelling cover letter (400-450 words, one page length) for this job application.
             
             STRUCTURE:
             1. Opening: Express genuine interest in the role and company
             2. Body Paragraphs (2-3):
                - Highlight relevant technical skills from resume that match job requirements
                - Showcase specific projects/achievements that align with the role
                - Demonstrate knowledge of the company's domain/industry
             3. Closing: Express enthusiasm and call to action
             
             TONE & STYLE:
             - Professional and confident (not arrogant)
             - Specific and achievement-focused (use numbers/metrics where possible)
             - Genuine and personable (avoid generic phrases)
             - Action-oriented language
             
             KEY POINTS TO EMPHASIZE:
             - Technical expertise in .NET/C# stack
             - 5.5 years of hands-on development experience
             - Experience in similar industries (if applicable)
             - Problem-solving abilities and continuous learning
             - Willingness to relocate within Canada if needed
             
             FORMATTING:
             - Use proper business letter format
             - Include [Your Name] placeholder for signature
             - Use [Hiring Manager] or [Hiring Team] for greeting
             - Professional closing (Sincerely, Best regards, etc.)
             
             AVOID:
             - Generic phrases like 'I am writing to apply...'
             - Repeating resume verbatim
             - Excessive use of 'I'
             - Desperate or overly humble tone
             - Mentioning salary unless it's exceptional
             
             Generate the complete cover letter now:";
        }

    }
}
