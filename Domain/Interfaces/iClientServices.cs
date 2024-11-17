using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iClientServices
    {

        Task<IEnumerable<Client>> GetClientAsync(); // firma de un metodo

        Task<Client> CreateClientAsync(Client client);

        Task<Client> GetClientByIdAsync(Guid id);

        Task<Client> EditClientAsync(Client client);

        Task<Client> DeleteClientAsync(Guid id);
    }
}
