using FluentValidation;
using GameOfChance.Models;

namespace GameOfChance.API.Validators
{
    public class BetRequestValidator : AbstractValidator<BetRequest>
    {
        public BetRequestValidator()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number field should not be empty")
                .GreaterThan(-1)
                .WithMessage("Number must be non negative"); ;
            RuleFor(x => x.Points).NotEmpty().WithMessage("Points should not be empty")
                .GreaterThan(0)
                .WithMessage("Max. number of team members must be greater than 0"); ;
        }
    }
}
