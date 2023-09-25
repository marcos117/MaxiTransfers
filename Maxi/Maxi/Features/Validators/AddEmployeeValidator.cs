using System.Text.RegularExpressions;
using FluentValidation;
using Maxi.Features.Employees;

namespace Maxi.Features.Validators;

public class AddEmployeeValidator: AbstractValidator<AddEmployee.RequestE>
{
    public AddEmployeeValidator()
    {
        RuleFor(employee => employee.Phone)
            .NotEmpty()
            .NotNull().WithMessage("Phone Number is required")
            .MinimumLength(10).WithMessage("Phone Number must not be less that 10 characteres")
            .MaximumLength(20).WithMessage("Phone Number must not exceed 20 characteres")
            .Matches(new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")).WithMessage("PhoneNumber not valid");
        
        RuleFor(employee => employee.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required")
            .Must(BeValidDate).WithMessage("Date of birth is required")
            .Must(BeValidAge).WithMessage("Invalid date, the user must be of legal age");
    }
    
    private bool BeValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }

    private bool BeValidAge(DateTime date)
    {
        int currentYear = DateTime.Now.Year;
        int dobYear = date.Year;

        if ((currentYear - dobYear) < 18)
        {
            return false;
        }

        return true;
    }
}