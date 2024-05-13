﻿using BookingWebApi.VievModels;
using FluentValidation;

namespace BookingWebApi.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateVievModel>
    {
        public UserUpdateValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Id property, Id is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Id property, the Id is required");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Email property, Email is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Email property, the Email is required");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Name property, Name is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Name property, the Name is required")
                .Matches(@"^[a-zA-Z]+$")
                .MaximumLength(20);

            RuleFor(c => c.Surname)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Surname property, Surname is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Surname property, the Surname is required")
                .Matches(@"^[a-zA-Z]+$")
                .MaximumLength(20);

            RuleFor(c => c.PhoneNumber)
                .Matches(@"^[0-9]+$")
                .WithMessage("enter only digits of your number")
                .MaximumLength(12);

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Password property, Password is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Password property, the Password is required");
        }
    }
}
