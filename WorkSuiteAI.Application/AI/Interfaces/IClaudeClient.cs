using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.AI.DTOs;

namespace WorkSuiteAI.Application.AI.Interfaces
{
    public interface IClaudeClient
    {
        Task<string> SendPromptAsync(string prompt);
        Task<ClaudeResponse> SendRequestAsync(ClaudeRequest request);
    }
}
