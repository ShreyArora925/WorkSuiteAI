using System;
using WorkSuiteAI.Application.AI.Interfaces;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;
using WorkSuiteAI.Domain.Interfaces;

namespace WorkSuiteAI.Application.Services;

/// <summary>
/// Service for AI-powered features using Claude API
/// </summary>
public class AIService : IAIService
{
    private readonly IEmployeeService _employeeService;
    private readonly IClaudeClient _claudeClient;
    private readonly ITimeEntryService _timeEntryService;

    public AIService(
        IEmployeeService employeeService,
        IClaudeClient claudeClient,
        ITimeEntryService timeEntryService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        _claudeClient = claudeClient ?? throw new ArgumentNullException(nameof(claudeClient));
        _timeEntryService = timeEntryService ?? throw new ArgumentNullException(nameof(timeEntryService));
    }

    public async Task<string> GeneratePerformanceReviewAsync(int employeeId)
    {

        var employee = await _employeeService.GetEmployeeById(employeeId);
        // build a detailed prompt
        var prompt = BuildPerformanceReviewPrompt(employee);

        var review = await _claudeClient.SendPromptAsync(prompt);
        // TODO: Implement actual AI integration
        return review;
    }

    private string BuildPerformanceReviewPrompt(EmployeeResponse employee)
    {
        var tenure = DateTime.UtcNow - employee.CreatedAt;
        var yearsOfService = Math.Round(tenure.TotalDays / 365.25, 1);


        // prompt building
        var prompt = $@"
            Generate a professional performance review for the following employee.
            
            EMPLOYEE INFORMATION:
            - Name: {employee.FirstName} {employee.LastName}
            - Department: {employee.Department}
            - Email: {employee.Email}
            - Years of Service: {yearsOfService} years
            - Hourly Rate: ${employee.HourlyRate}
            
            INSTRUCTIONS:
            - Write a professional, constructive performance review (200-300 words)
            - Include strengths and areas for improvement
            - Use a positive, encouraging tone
            - Structure: Introduction → Key Strengths → Areas for Growth → Conclusion
            - Be specific but professional
            
            Generate the performance review now:
            ";
        return prompt;

    }
}