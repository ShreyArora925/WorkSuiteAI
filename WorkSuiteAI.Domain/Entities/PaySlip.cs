using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkSuiteAI.Domain.Entities
{
    public class PaySlip
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PayrollRunId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RegularHours { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RegularPay { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimePay { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Deductions { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPay { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
