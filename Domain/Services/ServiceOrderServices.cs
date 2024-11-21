using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class ServiceOrderServices : iServiceOrderServices
    {
        private readonly DataBaseContext _context;

        public ServiceOrderServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<ServiceOrder> CreateServiceOrderAsync(ServiceOrder serviceOrder)
        {
            try
            {
                serviceOrder.Id = Guid.NewGuid();
                serviceOrder.CreatedDate = DateTime.Now;
                _context.ServiceOrders.Add(serviceOrder); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el ServiceOrder en la tabla
                return serviceOrder;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<ServiceOrder> DeleteServiceOrderAsync(Guid id)
        {

            try
            {
                var serviceOrder = await GetServiceOrderByIdAsync(id);

                if (serviceOrder == null)
                {
                    return null;
                }

                _context.ServiceOrders.Remove(serviceOrder); // Creacion del query "Delete from Service"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return serviceOrder;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ServiceOrder> EditServiceOrderAsync(ServiceOrder serviceOrder)
        {
            try
            {
                serviceOrder.ModifiedDate = DateTime.Now;
                _context.ServiceOrders.Update(serviceOrder);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return serviceOrder;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrderAsync()
        {

            try
            {
                var serviceOrders = await _context.ServiceOrders.ToListAsync();

                return serviceOrders;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ServiceOrder> GetServiceOrderByIdAsync(Guid id)
        {

            try
            {
                var serviceOrders = await _context.ServiceOrders.FirstOrDefaultAsync(x => x.Id == id);

                return serviceOrders;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

