namespace DAL.Entities
{
    public class Room
    {
        public required string Id { get; set; }

        public int Num {  get; set; } 

        public int Cup {  get; set; }

        public required string HotelId { get; set; }

        public string? UserId { get; set; }

        public Hotel? Hotel { get; set; }

        public User? User { get; set; }
    }
}
