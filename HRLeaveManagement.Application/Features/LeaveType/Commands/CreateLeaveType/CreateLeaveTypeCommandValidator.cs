using FluentValidation;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    public CreateLeaveTypeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(1).WithMessage("{PropertyName} cannot be less than 1");

    }
}
