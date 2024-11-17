using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class UserServices : iUserServices
    {
        private readonly DataBaseContext _context;

        public UserServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.Now;
                _context.Users.Add(user); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el bills en la tabla
                return user;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<User> DeleteUserAsync(Guid id)
        {

            try
            {
                var user = await GetUserByIdAsync(id);

                if (user == null)
                {
                    return null;
                }

                _context.Users.Remove(user); // Creacion del query "Delete from User"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> EditUserAsync(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;
                _context.Users.Add(user);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {

            try
            {
                var users = await _context.Users.ToListAsync();

                return users;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {

            try
            {
                var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                return users;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

