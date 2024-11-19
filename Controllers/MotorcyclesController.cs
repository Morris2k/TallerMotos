using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : Controller
    {
        private readonly iMotorcyclesServices _motorcyclesService;

        public MotorcyclesController(iMotorcyclesServices motorcyclesService)
        { 
            _motorcyclesService = motorcyclesService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Motorcycles>>> GetMotorcyclesAsync()
        {
            var motorcycless = await _motorcyclesService.GetMotorcyclesAsync();

            if (motorcycless == null || !motorcycless.Any()) return NotFound();
            
            return Ok(motorcycless);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Motorcycles>> GetMotorcyclesByIdAsync(Guid id)
        {
            var motorcycle = await _motorcyclesService.GetMotorcyclesByIdAsync(id);

            if (motorcycle == null) return NotFound();
            
            return Ok(motorcycle);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Motorcycles>> CreateMotorcyclesAsync(Motorcycles motorcycles)
        {
            try
            {
                var newMotorcycles = await _motorcyclesService.CreateMotorcyclesAsync(motorcycles);
                if (newMotorcycles == null) return NotFound();
                return Ok(newMotorcycles);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", motorcycles.Plate));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Motorcycles>> EditMotorcyclesAsync(Motorcycles motorcycles)
        {
            try
            {
                var editedMotorcycle = await _motorcyclesService.EditMotorcyclesAsync(motorcycles);
                if (editedMotorcycle == null) return NotFound();
                return Ok(editedMotorcycle);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", motorcycles.Plate));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Motorcycles>> DeleteMotorcyclesAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedMotorcycle = await _motorcyclesService.DeleteMotorcyclesAsync(id);
            if (deletedMotorcycle == null) return NotFound();
            return Ok(deletedMotorcycle);
        }
    }
}
