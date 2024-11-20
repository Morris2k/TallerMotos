using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class ServiceTypeServices : iServiceTypeServices
    {
        private readonly DataBaseContext _context;

        public ServiceTypeServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<ServiceType> CreateServiceTypeAsync(ServiceType serviceType)
        {
            try
            {
                serviceType.Id = Guid.NewGuid();
                serviceType.CreatedDate = DateTime.Now;
                _context.ServiceTypes.Add(serviceType); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el servicetype en la tabla
                return serviceType;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<ServiceType> DeleteServiceTypeAsync(Guid id)
        {

            try
            {
                var serviceType = await GetServiceTypeByIdAsync(id);

                if (serviceType == null)
                {
                    return null;
                }

                _context.ServiceTypes.Remove(serviceType); // Creacion del query "Delete from servicestype"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return serviceType;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ServiceType> EditServiceTypeAsync(ServiceType serviceType)
        {
            try
            {
                serviceType.ModifiedDate = DateTime.Now;
                _context.ServiceTypes.Add(serviceType);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return serviceType;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypeAsync()
        {

            try
            {
                var serviceTypes = await _context.ServiceTypes.ToListAsync();

                return serviceTypes;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ServiceType> GetServiceTypeByIdAsync(Guid id)
        {

            try
            {
                var serviceTypes = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);

                return serviceTypes;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
