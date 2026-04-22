using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.AI.DTOs
{
    public class ClaudeRequest
    {
        public string Model { get; set; } = "claude-sonnet-4-20241022";
        public int max_tokens { get; set; } = 4096;
        public List<ClaudeMessage> Messages { get; set; } = new();
    }

    public class  ClaudeMessage
    {
        public string Role { get; set; } = "user";

        public string Content { get; set; } = string.Empty;

    }
}
