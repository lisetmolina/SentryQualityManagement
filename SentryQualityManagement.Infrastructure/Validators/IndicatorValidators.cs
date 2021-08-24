using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class IndicatorValidator : AbstractValidator<IndicatorDto>
    {
        public IndicatorValidator()

        {

            RuleFor(indicator => indicator.IndicatorName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(indicator => indicator.IndicatorName)
                .Length(1, 1000)
                .WithMessage("La longitud del nombre debe estar entre 1 y 1000 caracteres");
           
                RuleFor(indicator => indicator.IndicatorDescription)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(indicator => indicator.IndicatorDescription)
                .Length(1, 1000)
                .WithMessage("La longitud del la descripcion debe estar entre 1 y 1000 caracteres");

            RuleFor(indicator => indicator.Formula)
                .NotNull()
                .WithMessage("La Formula no puede ser nula");

            RuleFor(indicator => indicator.Formula)
                .Length(1, 1000)
                .WithMessage("La longitud del la formula debe estar entre 1 y 1000 caracteres");

        }
    }
}
