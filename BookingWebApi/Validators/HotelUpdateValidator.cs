﻿using BookingWebApi.VievModels;
using FluentValidation;

namespace BookingWebApi.Validators
{
    public class HotelUpdateValidator : AbstractValidator<HotelUpdateVievModel>
    {
        public HotelUpdateValidator() 
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Id property, Id is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Id property, the Id is required");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Name property, Name is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Name property, the Name is required")
                .MaximumLength(20);

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty City property, City is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! City property, the City is required")
                .MaximumLength(20);
        }
    }
}
