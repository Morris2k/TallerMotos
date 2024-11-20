using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly iUserServices _userServices;

        public UsersController(iUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserAsync()
        {
            var users = await _userServices.GetUserAsync();

            if (users == null || !users.Any()) return NotFound();

            return Ok(users);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid id)
        {
            var users = await _userServices.GetUserByIdAsync(id);

            if (users == null) return NotFound();

            return Ok(users);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            try
            {
                var newUser = await _userServices.CreateUserAsync(user);
                if (newUser == null) return NotFound();
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", user.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<User>> EditUserAsync(User user)
        {
            try
            {
                var editedUser = await _userServices.EditUserAsync(user);
                if (editedUser == null) return NotFound();
                return Ok(editedUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", user.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<User>> DeleteUserAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedUser = await _userServices.DeleteUserAsync(id);
            if (deletedUser == null) return NotFound();
            return Ok(deletedUser);
        }
    }
}
