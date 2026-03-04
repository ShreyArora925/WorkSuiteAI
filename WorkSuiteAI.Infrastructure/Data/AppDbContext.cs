using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Domain.Entities;

namespace WorkSuiteAI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<PayrollRun> PayrollRuns { get; set; }
        public DbSet<PaySlip> paySlips { get; set; }
    }
}
