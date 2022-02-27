using FluentValidation;
using GameOfChance.Models.RequestModels;

namespace GameOfChance.API.Validators
{
    public class BetRequestValidator : AbstractValidator<BetRequest>
    {
        public BetRequestValidator()
        {
            RuleFor(x => x.number).NotEmpty().WithMessage("Password and Confirm Password do not match");
            RuleFor(x => x.Points).NotEmpty().WithMessage("Password and Confirm Password do not match");
        }
    }
}
