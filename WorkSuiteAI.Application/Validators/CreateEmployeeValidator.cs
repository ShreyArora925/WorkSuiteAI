using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Validators
{
    public class CreateEmployeeValidator :AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department is required")
                .MaximumLength(50).WithMessage("Department cannot exceed 50 characters");

            RuleFor(x => x.HourlyRate)
                .GreaterThanOrEqualTo(16.55m).WithMessage("Hourly rate must be at least minimum wage ($16.55)")
                .LessThanOrEqualTo(100).WithMessage("Hourly rate cannot exceed $100");
        }
    }
}
