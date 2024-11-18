using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iRepairServices
    {
       
        Task<IEnumerable<Repair>> GetRepairAsync(); // firma de un metodo

        Task<Repair> CreateRepairAsync(Repair repair);

        Task<Repair> GetRepairByIdAsync(Guid id);

        Task<Repair> EditRepairAsync(Repair repair);

        Task<Repair> DeleteRepairAsync(Guid id);
       
    }
}
