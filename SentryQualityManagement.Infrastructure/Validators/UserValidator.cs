using FluentValidation;
using SentryQualityManagement.Core.Dtos;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class UserValidator: AbstractValidator<UserDto>
    {
        public UserValidator()

        {
            RuleFor(user => user.UserName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(user => user.UserName)
                .Length(1, 1000)
                .WithMessage("La longitud del nombre debe estar entre 1 y 1000 caracteres");

            RuleFor(user => user.Email)
                .NotNull()
                .WithMessage("El Email no puede ser nulo");

            RuleFor(user => user.UserPassword)
                .NotNull()
                .WithMessage("El Password no puede ser nulo");
            
            RuleFor(user => user.Active);


            


        }
    }
}
    

