using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class ClientServices : iClientServices
    {
        private readonly DataBaseContext _context;

        public ClientServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Client> CreateClientAsync(Client client)
        {
            try
            {
                client.Id = Guid.NewGuid();
                client.CreatedDate = DateTime.Now;
                _context.Clients.Add(client); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el client en la tabla
                return client;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Client> DeleteClientAsync(Guid id)
        {

            try
            {
                var client = await GetClientByIdAsync(id);

                if (client == null)
                {
                    return null;
                }

                _context.Clients.Remove(client); // Creacion del query "Delete from client"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Client> EditClientAsync(Client client)
        {
            try
            {
                client.ModifiedDate = DateTime.Now;
                _context.Clients.Update(client);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Client>> GetClientAsync()
        {

            try
            {
                var clients = await _context.Clients.ToListAsync();

                return clients;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {

            try
            {
                var clients = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

                return clients;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

