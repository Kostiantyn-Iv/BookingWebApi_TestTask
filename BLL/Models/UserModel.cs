namespace BLL.Models
{
    public class UserModel
    {
        public string? Id { get; set; }

        public required string? Name { get; set; }

        public required string? Email { get; set; }

        public required string? Password { get; set; }

        public required string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? RoomId { get; set; }
    }
}
