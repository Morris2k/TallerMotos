using TallerMotos.DAL.Entities;

namespace TallerMotos.Domain.Interfaces
{
    public interface iUserServices
    {
        Task<IEnumerable<User>> GetUserAsync(); // firma de un metodo

        Task<User> CreateUserAsync(User user);

        Task<User> GetUserByIdAsync(Guid id);

        Task<User> EditUserAsync(User user);

        Task<User> DeleteUserAsync(Guid id);
    }
}
