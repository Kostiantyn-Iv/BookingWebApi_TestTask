namespace BLL.Models
{
    // Adapted entities for correct displaying in web api level
    public class HotelModel
    {
        public string Id { get; set; }

        public required string City { get; set; }

        public required string Name { get; set; }

        public IEnumerable<string>? RoomIds { get; set; }
    }
}
