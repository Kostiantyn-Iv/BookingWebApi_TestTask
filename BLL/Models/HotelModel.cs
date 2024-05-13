namespace BLL.Models
{
    public class HotelModel
    {
        public string Id { get; set; }

        public required string? City { get; set; }

        public required string? Name { get; set; }

        public IEnumerable<string>? RoomIds { get; set; }
    }
}
