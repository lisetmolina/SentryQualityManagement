using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class PeriodicityValidator : AbstractValidator<PeriodicityDto>
    {
        public PeriodicityValidator()
        {

            RuleFor(periodicity => periodicity.PeriodicityName)
                    .NotNull()
                    .WithMessage("El nombre no puede ser nulo");

            RuleFor(periodicity => periodicity.PeriodicityName)
                    .Length(1, 50)
                    .WithMessage("La longitud del nombre debe estar entre 1 y 50 caracteres");

            RuleFor(periodicity => periodicity.PeriodicityValue)
                    .NotNull()
                    .WithMessage("El valor no puede ser nulo");

            

        }
    }
}
