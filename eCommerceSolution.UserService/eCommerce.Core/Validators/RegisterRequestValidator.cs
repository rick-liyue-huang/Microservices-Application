using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid Email address format");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required").MinimumLength(3).WithMessage("at least three char");
            RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName is required")
                .MinimumLength(1).WithMessage("At least contain one charc")
                .MaximumLength(50).WithMessage("Cannot ovverride 50 char");
            RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Invalid Gender options");

        }
    }
}
