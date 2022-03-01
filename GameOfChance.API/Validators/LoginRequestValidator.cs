using FluentValidation;
using GameOfChance.Models;

namespace GameOfChance.API.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("User name should not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field should not be empty.");
        }
    }
}
