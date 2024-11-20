using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : Controller
    {
        private readonly iBillServices _billServices;

        public BillsController(iBillServices billServices) 
        {
            _billServices = billServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillAsync()
        {
            var bills = await _billServices.GetBillAsync();

            if (bills == null || !bills.Any()) return NotFound();

            return Ok(bills);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Bill>> GetBillByIdAsync(Guid id)
        {
            var bills = await _billServices.GetBillByIdAsync(id);

            if (bills == null) return NotFound();

            return Ok(bills);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Motorcycles>> CreateBillAsync(Bill bill)
        {
            try
            {
                var newBill = await _billServices.CreateBillAsync(bill);
                if (newBill == null) return NotFound();
                return Ok(newBill);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", bill.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Bill>> EditBillAsync(Bill bill)
        {
            try
            {
                var editedBill = await _billServices.EditBillAsync(bill);
                if (editedBill == null) return NotFound();
                return Ok(editedBill);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", bill.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Bill>> DeleteBillrAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedbill = await _billServices.DeleteBillrAsync(id);
            if (deletedbill == null) return NotFound();
            return Ok(deletedbill);
        }
    }
}
