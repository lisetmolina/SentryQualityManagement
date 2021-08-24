using FluentValidation;
using SentryQualityManagement.Core.Dtos;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class AreaValidator : AbstractValidator<AreaDto>
    {
        public AreaValidator()

        {
            
            RuleFor(area => area.AreaName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(area => area.AreaName)
                .Length(1, 1000)
                .WithMessage("La longitud del nombre debe estar entre 1 y 1000 caracteres");

        }
    }  
}
