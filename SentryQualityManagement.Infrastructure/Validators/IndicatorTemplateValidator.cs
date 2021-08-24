using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class IndicatorTemplateValidator : AbstractValidator<IndicatorTemplateDto>
    {
        public IndicatorTemplateValidator()
        {
            RuleFor(indicatorTemplate => indicatorTemplate.ElementName)
               .NotNull()
               .WithMessage("El nombre no puede ser nulo");

            RuleFor(indicatorTemplate => indicatorTemplate.ElementName)
                .Length(1, 1000)
                .WithMessage("La longitud del nombre debe estar entre 1 y 1000 caracteres");

            RuleFor(indicatorTemplate => indicatorTemplate.ElementValue)
              .NotNull()
              .WithMessage("El valor no puede ser nulo");

            RuleFor(indicatorTemplate => indicatorTemplate.ElementDate)
              .NotNull()
              .WithMessage("La fecha no puede ser nulo");
        }

    }
}
