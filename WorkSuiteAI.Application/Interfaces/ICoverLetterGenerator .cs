using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface ICoverLetterGenerator
    {
        Task<string> GenerateCoverLetterAsync(JobMatch job, string resume);
    }
}
