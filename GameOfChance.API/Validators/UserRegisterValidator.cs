using FluentValidation;
using GameOfChance.Models;

namespace GameOfChance.API.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("User name should not be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email should not be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter the valid email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field should not be empty.");
        }
    }
}
