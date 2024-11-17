using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;


namespace TallerMotos.Domain.Services
{
    public class BillServices : iBillServices
    {
        private readonly DataBaseContext _context;

        public BillServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            try
            {
                bill.Id = Guid.NewGuid();
                bill.CreatedDate = DateTime.Now;
                _context.Bills.Add(bill); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el bills en la tabla
                return bill;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Bill> DeleteBillrAsync(Guid id)
        {

            try
            {
                var bill = await GetBillByIdAsync(id);

                if (bill == null)
                {
                    return null;
                }

                _context.Bills.Remove(bill); // Creacion del query "Delete from Bills"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Bill> EditBillAsync(Bill bill)
        {
            try
            {
                bill.ModifiedDate = DateTime.Now;
                _context.Bills.Add(bill);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Bill>> GetBillAsync()
        {

            try
            {
                var bills = await _context.Bills.ToListAsync();

                return bills;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Bill> GetBillByIdAsync(Guid id)
        {

            try
            {
                var bills = await _context.Bills.FirstOrDefaultAsync(x => x.Id == id);

                return bills;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
    

