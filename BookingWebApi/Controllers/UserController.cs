using BLL.Abstraction;
using BLL.Models;
using BookingWebApi.VievModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _service = userService;

        [HttpPost("/newuser")]
        public async Task<ActionResult> AddRoom([FromBody] RegistrationVievModel model)
        {
            UserModel userModel = new UserModel()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
            };

            await _service.AddAsync(userModel).ConfigureAwait(false);
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
        public async Task<ActionResult> UpdateRoom([FromBody] UserUpdateVievModel model)
        {
            UserModel userModel = new UserModel()
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
            };

            await _service.UpdateAsync(userModel).ConfigureAwait(false);
            return Ok(model);
        }
    }
}
