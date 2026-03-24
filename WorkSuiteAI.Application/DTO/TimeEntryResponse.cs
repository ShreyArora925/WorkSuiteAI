using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Application.DTO
{
    public class TimeEntryResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public decimal HoursWorked { get; set; }
        public bool IsOvertime { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
