using Microsoft.AspNetCore.Mvc;
using TallerMotos.DAL.Entities;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

namespace TallerMotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly iEmployeeServices _employeeServices;

        public EmployeesController(iEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeAsync()
        {
            var employees = await _employeeServices.GetEmployeeAsync();

            if (employees == null || !employees.Any()) return NotFound();

            return Ok(employees);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(Guid id)
        {
            var employees = await _employeeServices.GetEmployeeByIdAsync(id);

            if (employees == null) return NotFound();

            return Ok(employees);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Employee>> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                var newEmployee = await _employeeServices.CreateEmployeeAsync(employee);
                if (newEmployee == null) return NotFound();
                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", employee.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Employee>> EditEmployeeAsync(Employee employee)
        {
            try
            {
                var editedEmployee = await _employeeServices.EditEmployeeAsync(employee);
                if (editedEmployee == null) return NotFound();
                return Ok(editedEmployee);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", employee.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Employee>> DeleteEmployeeAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedEmployee = await _employeeServices.DeleteEmployeeAsync(id);
            if (deletedEmployee == null) return NotFound();
            return Ok(deletedEmployee);
        }
    }
}
