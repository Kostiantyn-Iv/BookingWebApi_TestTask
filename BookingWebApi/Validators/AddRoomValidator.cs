using BookingWebApi.VievModels;
using FluentValidation;

namespace BookingWebApi.Validators
{
    public class AddRoomValidator : AbstractValidator<AddRoomVievModel>
    {
        public AddRoomValidator() 
        {
            // Configures a validation rule for the Cupacity property:
            // - InclusiveBetween: Ensures the Cupacity property is between the specified range (1 to 10).

            RuleFor(x => x.HotelId)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty HotelId property, HotelId is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! HotelId property, the HotelId is required");

            RuleFor(x => x.Cupacity)
                .InclusiveBetween(1, 10)
                .WithMessage("select the number of beds in the new room, value from 1 to 10");

            RuleFor(x => x.Num)
                .InclusiveBetween(1, 1000)
                .WithMessage("select the number of the new room, value from 1 to 1000");

        }
    }
}
