using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployeeAsync(); // firma de un metodo

        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(Guid id);

        Task<Employee> EditEmployeeAsync(Employee employee);

        Task<Employee> DeleteEmployeeAsync(Guid id);
    }
}
