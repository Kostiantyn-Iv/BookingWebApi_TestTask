namespace DAL.Entities
{
    public class Hotel
    {
        public required string Id { get; set; }

        public required string City { get; set; }

        public required string Name { get; set; }

        public required IEnumerable<Room>? Rooms {  get; set; }
    }
}
