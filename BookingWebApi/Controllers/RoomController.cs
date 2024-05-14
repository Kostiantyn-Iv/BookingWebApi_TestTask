using BLL.Abstraction;
using BLL.Models;
using BookingWebApi.VievModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController(IRoomService roomService) : ControllerBase
    {
        private readonly IRoomService _service = roomService;

        [HttpPost("/newroom")]
        public async Task<ActionResult> AddRoom([FromBody] AddRoomVievModel model)
        {
            RoomModel roomModel = new RoomModel()
            {
                HotelId = model.HotelId,
                Num = model.Num,
                Cup = model.Cupacity,
            };

            await _service.AddAsync(roomModel).ConfigureAwait(false);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRooms()
        {
            var hotelModels = await _service.GetAllAsync().ConfigureAwait(false);

            return Ok(hotelModels);
        }

        [HttpDelete("remove/{key}")]
        public async Task<ActionResult> DeleteRoom(string key)
        {
            await _service.DeleteByKeyAsync(key).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateRoom([FromBody] RoomUpdateVievModel model)
        {
            RoomModel roomModel = new RoomModel()
            {
                Id = model.Id,
                HotelId = model.HotelId,
                Num = model.Num,
                Cup = model.Cupacity,
            };

            await _service.UpdateAsync(roomModel).ConfigureAwait(false);
            return Ok(model);
        }

        [HttpPut("{roomId}/user/{userId}/reserve")]
        public async Task<ActionResult> ReserveRoom(string roomId, string userId)
        {
            await _service.RoomReservation(userId, roomId).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut("{roomId}/release")]
        public async Task<ActionResult> ReserveRoom(string roomId)
        {
            await _service.RoomRelease(roomId).ConfigureAwait(false);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoom(string id)
        {
            RoomModel room = await _service.GetByKeyAsync(id).ConfigureAwait(false);

            return Ok(room);
        }

        [HttpGet("by/filter")]
        public async Task<ActionResult> GetRoomsByFilter([FromQuery] RoomFilterVievModel model)
        {
            IEnumerable<RoomModel> rooms = await _service.GetRoomByFilterAsync(model.City, model.NumOfBeds).ConfigureAwait(false);

            return Ok(rooms);
        }

    }
}
