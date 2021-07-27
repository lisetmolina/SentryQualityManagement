using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class ModuleValidator : AbstractValidator<ModuleDto>
    {
        public ModuleValidator()

        {
            RuleFor(module => module.ModuleName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(module => module.ModuleName)
                .Length(1, 50)
                .WithMessage("La longitud del nombre debe estar entre 1 y 50 caracteres");

            RuleFor(module => module.ModuleDescription)
                .NotNull()
                .WithMessage("La descripción no puede ser nula");

            RuleFor(module => module.ModuleDescription)
                .Length(1, 100)
                .WithMessage("La longitud de la descripción debe estar entre 10 y 50 caracteres");






        }
    }
}
