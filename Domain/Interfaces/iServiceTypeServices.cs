using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iServiceTypeServices
    {
        Task<IEnumerable<ServiceType>> GetServiceTypeAsync(); // firma de un metodo

        Task<ServiceType> CreateServiceTypeAsync(ServiceType serviceType);

        Task<ServiceType> GetServiceTypeByIdAsync(Guid id);

        Task<ServiceType> EditServiceTypeAsync(ServiceType serviceType);

        Task<ServiceType> DeleteServiceTypeAsync(Guid id);
    }
}
