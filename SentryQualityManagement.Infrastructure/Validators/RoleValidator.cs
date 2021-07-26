using FluentValidation;
using SentryQualityManagement.Core.DTOs;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()

        {
            RuleFor(role => role.RoleName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(role => role.RoleName)
                .Length(1, 50)
                .WithMessage("La longitud del nombre debe estar entre 1 y 50 caracteres");

            RuleFor(role => role.RoleDescription)
                .NotNull()
                .WithMessage("La descripción no puede ser nula");

            RuleFor(role => role.RoleDescription)
                .Length(1, 100)
                .WithMessage("La longitud de la descripción debe estar entre 10 y 50 caracteres");

            RuleFor(role => role.Active);
               

           
                

        }
    }
}


            
