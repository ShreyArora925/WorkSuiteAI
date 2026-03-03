using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Domain.Entities
{
    public class PayrollRun
    {
        public int Id { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime RunDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty; // Draft, Processing, Completed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
