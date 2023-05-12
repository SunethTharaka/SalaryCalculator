using FluentValidation;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Validators
{
    public class SalaryDTOValidator : AbstractValidator<SalaryDTO>
    {
        public SalaryDTOValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Please enter employee's first name");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Please enter employee's last name");
            RuleFor(x => x.AnnualSalary).NotEmpty().WithMessage("Please enter employee's annual salary");
            RuleFor(x => x.SupperRate).NotEmpty().WithMessage("Please enter employee's super rate");
            RuleFor(x => x.PayPeriod).NotEmpty().WithMessage("Please enter pay period");
        }
    }
}
