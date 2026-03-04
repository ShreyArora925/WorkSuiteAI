using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.DTO
{
    public class EmployeeResponse
    {
        public int Id {  get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
