using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class MotorcyclesServices : iMotorcyclesServices
    {
        private readonly DataBaseContext _context;

        public MotorcyclesServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Motorcycles> CreateMotorcyclesAsync(Motorcycles motorcycles)
        {
            try
            {
                motorcycles.Id = Guid.NewGuid();
                motorcycles.CreatedDate = DateTime.Now;
                _context.Motorcycles.Add(motorcycles); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el bills en la tabla
                return motorcycles;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Motorcycles> DeleteMotorcyclesAsync(Guid id)
        {

            try
            {
                var motorcycles = await GetMotorcyclesByIdAsync(id);

                if (motorcycles == null)
                {
                    return null;
                }

                _context.Motorcycles.Remove(motorcycles); // Creacion del query "Delete from Bills"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return motorcycles;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Motorcycles> EditMotorcyclesAsync(Motorcycles motorcycles)
        {
            try
            {
                motorcycles.ModifiedDate = DateTime.Now;
                _context.Motorcycles.Add(motorcycles);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return motorcycles;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Motorcycles>> GetMotorcyclesAsync()
        {

            try
            {
                var motorcycless = await _context.Motorcycles.ToListAsync();

                return motorcycless;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Motorcycles> GetMotorcyclesByIdAsync(Guid id)
        {

            try
            {
                var motorcycless = await _context.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);

                return motorcycless;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

