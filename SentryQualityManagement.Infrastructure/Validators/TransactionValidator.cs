using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionDto>
    {
        public TransactionValidator()

        {
            RuleFor(transaction => transaction.TransactionName)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(transaction => transaction.TransactionName)
                .Length(1, 50)
                .WithMessage("La longitud del nombre debe estar entre 1 y 50 caracteres");

        }
    }
}
