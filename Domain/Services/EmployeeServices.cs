using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;

namespace TallerMotos.Domain.Services
{
    public class EmployeeServices : iEmployeeServices
    {
        private readonly DataBaseContext _context;

        public EmployeeServices(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                employee.Id = Guid.NewGuid();
                employee.CreatedDate = DateTime.Now;
                _context.Employees.Add(employee); // permite crear el objeto en mi base de datos
                await _context.SaveChangesAsync(); // guarda el employee en la tabla
                return employee;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Employee> DeleteEmployeeAsync(Guid id)
        {

            try
            {
                var employee = await GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return null;
                }

                _context.Employees.Remove(employee); // Creacion del query "Delete from Employee"
                await _context.SaveChangesAsync(); // ejecucion del Query

                return employee;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            try
            {
                employee.ModifiedDate = DateTime.Now;
                _context.Employees.Add(employee);   //virtualizo el objeto
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {

            try
            {
                var employees = await _context.Employees.ToListAsync();

                return employees;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {

            try
            {
                var employees = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

                return employees;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

