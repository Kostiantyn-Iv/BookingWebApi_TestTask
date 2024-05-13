namespace BookingWebApi.VievModels
{
    public class RoomUpdateVievModel
    {
        public required string Id { get; set; }

        public int Num { get; set; }

        public int Cupacity { get; set; }

        public required string HotelId { get; set; }
    }
}
