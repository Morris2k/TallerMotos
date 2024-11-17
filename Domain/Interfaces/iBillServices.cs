using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iBillServices
    {
        Task<IEnumerable<Bill>> GetBillAsync(); // firma de un metodo

        Task<Bill> CreateBillAsync(Bill bill);

        Task<Bill> GetBillByIdAsync(Guid id);

        Task<Bill> EditBillAsync(Bill bill);

        Task<Bill> DeleteBillrAsync(Guid id);
    }
}
