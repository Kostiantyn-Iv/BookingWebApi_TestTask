namespace BookingWebApi.VievModels
{
    public class RegistrationVievModel
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public required string Password { get; set; }
    }
}
