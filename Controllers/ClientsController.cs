using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly iClientServices _clientService;

        public ClientsController(iClientServices clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientAsync()
        {
            var clients = await _clientService.GetClientAsync();

            if (clients == null || !clients.Any()) return NotFound();

            return Ok(clients);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Client>> GetClientByIdAsync(Guid id)
        {
            var clients = await _clientService.GetClientByIdAsync(id);

            if (clients == null) return NotFound();

            return Ok(clients);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Client>> CreateClientAsync(Client client)
        {
            try
            {
                var newClient = await _clientService.CreateClientAsync(client);
                if (newClient == null) return NotFound();
                return Ok(newClient);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", client.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Client>> EditClientAsync(Client client)
        {
            try
            {
                var editedClient = await _clientService.EditClientAsync(client);
                if (editedClient == null) return NotFound();
                return Ok(editedClient);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", client.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Client>> DeleteClientAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedClient = await _clientService.DeleteClientAsync(id);
            if (deletedClient == null) return NotFound();
            return Ok(deletedClient);
        }
    }
}
