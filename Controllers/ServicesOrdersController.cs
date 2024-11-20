using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesOrdersController : Controller
    {
        private readonly iServiceOrderServices _serviceOrderService;

        public ServicesOrdersController(iServiceOrderServices serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ServiceOrder>>> GetServiceOrderAsync()
        {
            var serviceOrders = await _serviceOrderService.GetServiceOrderAsync();

            if (serviceOrders == null || !serviceOrders.Any()) return NotFound();

            return Ok(serviceOrders);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ServiceOrder>> GetServiceOrderByIdAsync(Guid id)
        {
            var serviceOrders = await _serviceOrderService.GetServiceOrderByIdAsync(id);

            if (serviceOrders == null) return NotFound();

            return Ok(serviceOrders);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<ServiceOrder>> CreateServiceOrderAsync(ServiceOrder serviceOrder)
        {
            try
            {
                var newServiceOrder = await _serviceOrderService.CreateServiceOrderAsync(serviceOrder);
                if (newServiceOrder == null) return NotFound();
                return Ok(newServiceOrder);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", serviceOrder.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<ServiceOrder>> EditServiceOrderAsync(ServiceOrder serviceOrder)
        {
            try
            {
                var editedServiceOrder = await _serviceOrderService.EditServiceOrderAsync(serviceOrder);
                if (editedServiceOrder == null) return NotFound();
                return Ok(editedServiceOrder);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", serviceOrder.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<ServiceOrder>> DeleteServiceOrderAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedOrderService = await _serviceOrderService.DeleteServiceOrderAsync(id);
            if (deletedOrderService == null) return NotFound();
            return Ok(deletedOrderService);
        }
    }
}
