using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iMotorcyclesServices
    {
        Task<IEnumerable<Motorcycles>> GetMotorcyclesAsync(); // firma de un metodo

        Task<Motorcycles> CreateMotorcyclesAsync(Motorcycles motorcycles);

        Task<Motorcycles> GetMotorcyclesByIdAsync(Guid id);

        Task<Motorcycles> EditMotorcyclesAsync(Motorcycles motorcycles);

        Task<Motorcycles> DeleteMotorcyclesAsync(Guid id);
    }
}
