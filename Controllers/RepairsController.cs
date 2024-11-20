using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    public class RepairsController : Controller
    {
        private readonly iRepairServices _repairServices;

        public  RepairsController(iRepairServices repairServices)
        {
            _repairServices = repairServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Repair>>> GetRepairAsync()
        {
            var repairs = await _repairServices.GetRepairAsync();

            if (repairs == null || !repairs.Any()) return NotFound();

            return Ok(repairs);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Repair>> GetRepairByIdAsync(Guid id)
        {
            var repairs = await _repairServices.GetRepairByIdAsync(id);

            if (repairs == null) return NotFound();

            return Ok(repairs);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Repair>> CreateRepairAsync(Repair repair)
        {
            try
            {
                var newRepair = await _repairServices.CreateRepairAsync(repair);
                if (newRepair == null) return NotFound();
                return Ok(newRepair);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", repair.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Repair>> EditRepairAsync(Repair repair)
        {
            try
            {
                var editedRepair = await _repairServices.EditRepairAsync(repair);
                if (editedRepair == null) return NotFound();
                return Ok(editedRepair);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", repair.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Repair>> DeleteRepairAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedRepair = await _repairServices.DeleteRepairAsync(id);
            if (deletedRepair == null) return NotFound();
            return Ok(deletedRepair);
        }
    }
}
