using Clinic.ViewModels.Card;
using FluentValidation;

namespace Clinic.Validations.Card
{
    public class CartCreateValidator : AbstractValidator<CardCreateVM>
    {
        public CartCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("can not be empty !")
                .NotNull()
                .WithMessage("can not be null!")
                .MaximumLength(100)
                .WithMessage("length can not  be more than 100 !");

            RuleFor(x => x.Surname).NotEmpty()
                .WithMessage("can not be empty !")
                .NotNull()
                .WithMessage("can not be null!")
                .MaximumLength(100)
                .WithMessage("length can not  be more than 100 !");
            RuleFor(x => x.CoverFile).NotEmpty()
                .WithMessage("can not be empty !")
                .NotNull()
                .WithMessage("can not be null!");

        }
    }
}
