using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class IndicatorResultValidators : AbstractValidator<IndicatorResultDto>
    {
        public IndicatorResultValidators()

        {
            RuleFor(indicatorResult => indicatorResult.Formula)
               .NotNull()
               .WithMessage("El nombre no puede ser nulo");

            RuleFor(indicatorResult => indicatorResult.Formula);
      
                

        }
    }
}
