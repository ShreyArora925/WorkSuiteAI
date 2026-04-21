using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.AI.DTOs;
using WorkSuiteAI.Domain.Entities;

namespace WorkSuiteAI.Application.Interfaces;

/// <summary>
/// Service for AI-powered features in WorkSuiteAI
/// </summary>
public interface IAIService
{
    /// <summary>
    /// Generates a professional performance review for an employee using AI
    /// </summary>
    /// <param name="employeeId">The ID of the employee to generate a review for</param>
    /// <returns>The generated performance review text</returns>
    Task<string> GeneratePerformanceReviewAsync(int employeeId);
}
