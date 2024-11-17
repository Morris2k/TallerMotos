using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iBuyServices
    {
        Task<IEnumerable<Buy>> GetBuyAsync(); // firma de un metodo

        Task<Buy> CreateBuyAsync(Buy buy);

        Task<Buy> GetBuyByIdAsync(Guid id);

        Task<Buy> EditBuyAsync(Buy buy);

        Task<Buy> DeleteBuyrAsync(Guid id);
    }
}
