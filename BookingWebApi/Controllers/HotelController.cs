using BLL.Abstraction;
using BLL.Models;
using BookingWebApi.VievModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController(IHotelService hotelService) : ControllerBase
    {
        private readonly IHotelService _service = hotelService;

        [HttpPost("/newhotel")]
        public async Task<ActionResult> AddHotel([FromBody] AddHotelVievModel model)
        {
            HotelModel hotelModel = new HotelModel()
            {
                City = model.City,
                Name = model.Name,
            };

            await _service.AddAsync(hotelModel).ConfigureAwait(false);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHotels()
        {
            var hotelModels = await _service.GetAllAsync().ConfigureAwait(false);

            return Ok(hotelModels);
        }

        [HttpDelete("remove/{key}")]
        public async Task<ActionResult> DeleteHotel(string key)
        {
            await _service.DeleteByKeyAsync(key).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateHotel([FromBody] HotelUpdateVievModel model)
        {
            HotelModel hotelModel = new HotelModel()
            {
                Id = model.Id,
                City = model.City,
                Name = model.Name,
            };

            await _service.UpdateAsync(hotelModel).ConfigureAwait(false);
            return Ok(model);
        }

    }
}
