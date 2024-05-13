namespace BLL.Models
{
    public class RoomModel
    {
        public string? Id { get; set; }

        public int Num { get; set; }

        public int Cup { get; set; }

        public required string HotelId { get; set; }

        public string? UserId { get; set; }
    }
}
