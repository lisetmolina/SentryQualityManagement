﻿using FluentValidation;
using SentryQualityManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

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
                .Length(1, 50)
                .WithMessage("La longitud del nombre debe estar entre 1 y 50 caracteres");

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
    
