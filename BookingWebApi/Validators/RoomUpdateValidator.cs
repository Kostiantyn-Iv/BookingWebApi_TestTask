using BookingWebApi.VievModels;
using FluentValidation;

namespace BookingWebApi.Validators
{
    public class RoomUpdateValidator : AbstractValidator<RoomUpdateVievModel>
    {
        public RoomUpdateValidator() 
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage($"Incoming entity has an empty Id property, Id is required")
                .NotNull()
                .WithMessage("Incoming entity has an null! Id property, the Id is required");

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
