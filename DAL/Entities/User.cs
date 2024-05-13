
namespace DAL.Entities
{
    public class User
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public string? Surname { get; set; }

        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public required string Password { get; set; }

        public string? RoomId { get; set; }

        public Room? Room { get; set; }
    }
}
