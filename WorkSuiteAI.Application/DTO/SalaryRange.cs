using System;

namespace WorkSuiteAI.Application.DTO
{
    public record SalaryRange
    {
        public int Min { get; init; }
        public int Max { get; init; }

        public SalaryRange()
        {
        }

        public SalaryRange(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Minimum salary cannot be greater than maximum salary", nameof(min));

            if (min < 0 || max < 0)
                throw new ArgumentException("Salary cannot be negative");

            Min = min;
            Max = max;
        }
    }
}