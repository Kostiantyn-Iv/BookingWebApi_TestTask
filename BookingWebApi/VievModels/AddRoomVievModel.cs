namespace BookingWebApi.VievModels
{
    public class AddRoomVievModel
    {
        public int Num { get; set; }

        public int Cupacity { get; set; }

        public required string HotelId { get; set; }
    }
}
