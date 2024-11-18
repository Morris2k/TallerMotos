using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class BuyServices : iBuyServices
    {
        private readonly DataBaseContext _context;

        public BuyServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Buy> CreateBuyAsync(Buy buy)
        {
            try
            {
                buy.Id = Guid.NewGuid();
                buy.CreatedDate = DateTime.Now;
                _context.Buys.Add(buy); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el bills en la tabla
                return buy;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Buy> DeleteBuyAsync(Guid id)
        {

            try
            {
                var buy = await GetBuyByIdAsync(id);

                if (buy == null)
                {
                    return null;
                }

                _context.Buys.Remove(buy); // Creacion del query "Delete from Bills"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return buy;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Buy> EditBuyAsync(Buy buy)
        {
            try
            {
                buy.ModifiedDate = DateTime.Now;
                _context.Buys.Add(buy);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return buy;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Buy>> GetBuyAsync()
        {

            try
            {
                var buys = await _context.Buys.ToListAsync();

                return buys;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Buy> GetBuyByIdAsync(Guid id)
        {

            try
            {
                var buys = await _context.Buys.FirstOrDefaultAsync(x => x.Id == id);

                return buys;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    
    }
}

