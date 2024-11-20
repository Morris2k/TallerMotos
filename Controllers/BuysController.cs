using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : Controller
    {
        private readonly iBuyServices _buyService;

        public BuysController(iBuyServices buyService)
        {
            _buyService = buyService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Buy>>> GetBuyAsync()
        {
            var buys = await _buyService.GetBuyAsync();

            if (buys == null || !buys.Any()) return NotFound();

            return Ok(buys);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Buy>> GetBuyByIdAsync(Guid id)
        {
            var buys = await _buyService.GetBuyByIdAsync(id);

            if (buys == null) return NotFound();

            return Ok(buys);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Buy>> CreateBuyAsync(Buy buy)
        {
            try
            {
                var newBuy = await _buyService.CreateBuyAsync(buy);
                if (newBuy == null) return NotFound();
                return Ok(newBuy);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", buy.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Buy>> EditBuyAsync(Buy buy)
        {
            try
            {
                var editedBuy = await _buyService.EditBuyAsync(buy);
                if (editedBuy == null) return NotFound();
                return Ok(editedBuy);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", buy.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Buy>> DeleteBuyAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedBuy = await _buyService.DeleteBuyAsync(id);
            if (deletedBuy == null) return NotFound();
            return Ok(deletedBuy);
        }
    }
}
