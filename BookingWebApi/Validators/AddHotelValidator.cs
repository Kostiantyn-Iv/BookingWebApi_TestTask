using BookingWebApi.VievModels;
using FluentValidation;

namespace BookingWebApi.Validators
{
    public class AddHotelValidator : AbstractValidator<AddHotelVievModel>
    {
        public AddHotelValidator() 
        {
            // Configures a validation rule for the Name property:
            // - NotEmpty: Ensures the Name property is not empty.
            // - WithMessage: Specifies a custom error message when the property is empty.
            // - NotNull: Ensures the Name property is not null.
            // - MaximumLength: Sets the maximum length allowed for the Name property.
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
