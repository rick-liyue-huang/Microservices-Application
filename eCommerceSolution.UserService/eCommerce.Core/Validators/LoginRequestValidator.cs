using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            // Eamil
            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
