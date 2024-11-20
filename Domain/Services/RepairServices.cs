using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class RepairServices : iRepairServices
    {
        private readonly DataBaseContext _context;

        public RepairServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Repair> CreateRepairAsync(Repair repair)
        {
            try
            {
                repair.Id = Guid.NewGuid();
                repair.CreatedDate = DateTime.Now;
                _context.Repairs.Add(repair); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el repair en la tabla
                return repair;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Repair> DeleteRepairAsync(Guid id)
        {

            try
            {
                var repair = await GetRepairByIdAsync(id);

                if (repair == null)
                {
                    return null;
                }

                _context.Repairs.Remove(repair); // Creacion del query "Delete from Repair"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return repair;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Repair> EditRepairAsync(Repair repair)
        {
            try
            {
                repair.ModifiedDate = DateTime.Now;
                _context.Repairs.Add(repair);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return repair;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Repair>> GetRepairAsync()
        {

            try
            {
                var repairs = await _context.Repairs.ToListAsync();

                return repairs;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Repair> GetRepairByIdAsync(Guid id)
        {

            try
            {
                var repairs = await _context.Repairs.FirstOrDefaultAsync(x => x.Id == id);

                return repairs;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

