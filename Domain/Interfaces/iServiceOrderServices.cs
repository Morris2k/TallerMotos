using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iServiceOrderServices
    {
        Task<IEnumerable<ServiceOrder>> GetServiceOrderAsync(); // firma de un metodo

        Task<ServiceOrder> CreateServiceOrderAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> GetServiceOrderByIdAsync(Guid id);

        Task<ServiceOrder> EditServiceOrderAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> DeleteServiceOrderAsync(Guid id);
    }
}
