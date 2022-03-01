using FluentValidation;
using GameOfChance.Models;

namespace GameOfChance.API.Validators
{
    public class BetRequestValidator : AbstractValidator<BetRequest>
    {
        public BetRequestValidator()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number field should not be empty");
            RuleFor(x => x.Points).NotEmpty().WithMessage("Points should not be empty");
        }
    }
}
