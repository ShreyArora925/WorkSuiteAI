using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.AI.DTOs
{
    public class ClaudeResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public List<ClaudeContent> Content { get; set; } = new();
        public ClaudeUsage? Usage { get; set; }
    }

    public class ClaudeContent
    {
        public string Type { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    public class ClaudeUsage
    {
        public int InputTokens { get; set; }
        public int OutputTokens { get; set; }
    }
}
