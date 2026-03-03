using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkSuiteAI.Domain.Entities
{
    public class TimeEntry
    {
        public int Id { get; set; } 
        public int EmployeeID { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "decimal(18,2)")]
        public Decimal HoursWorked { get; set; }
        public bool OverTime {  get; set; }    
    }
}
