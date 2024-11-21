using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : Controller
    {
        private readonly iServiceTypeServices _serviceTypeService;

        public ServiceTypesController(iServiceTypeServices serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypeAsync()
        {
            var serviceType = await _serviceTypeService.GetServiceTypeAsync();

            if (serviceType == null || !serviceType.Any()) return NotFound();

            return Ok(serviceType);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceTypeByIdAsync(Guid id)
        {
            var serviceType = await _serviceTypeService.GetServiceTypeByIdAsync(id);

            if (serviceType == null) return NotFound();

            return Ok(serviceType);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<ServiceType>> CreateServiceTypeAsync(ServiceType serviceType)
        {
            try
            {
                var newServiceType = await _serviceTypeService.CreateServiceTypeAsync(serviceType);
                if (newServiceType == null) return NotFound();
                return Ok(newServiceType);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", serviceType.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<ServiceType>> EditServiceTypeAsync(ServiceType serviceType)
        {
            try
            {
                var editedServiceType = await _serviceTypeService.EditServiceTypeAsync(serviceType);
                if (editedServiceType == null) return NotFound();
                return Ok(editedServiceType);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", serviceType.Code));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<ServiceType>> DeleteServiceTypeAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedServiceType = await _serviceTypeService.DeleteServiceTypeAsync(id);
            if (deletedServiceType == null) return NotFound();
            return Ok(deletedServiceType);
        }
    }
}
