using Clinic.ViewModels.Department;
using FluentValidation;

namespace Clinic.Validations.Department
{
    public class DepartmentCreateValidator : AbstractValidator<DepartmentCreateVM>
    {
        public DepartmentCreateValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty()
                .WithMessage("can not be empty !")
                .NotNull()
                .WithMessage("can not be null!")
                .MaximumLength(100)
                .WithMessage("length can not  be more than 100 !");



        }
    }
}
