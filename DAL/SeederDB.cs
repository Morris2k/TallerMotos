using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Data;
using System.Numerics;
using TallerMotos.DAL.Entities;

namespace TallerMotos.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        private Guid _i;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
        //Metodo llamado SeederAsync
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            //A partir de aquí vamos a ir creando métodos que me sirven para prepoblar mi BD
            await PopulateClientsAsync();
            await PopulateEmployeeAsync();
            await PopulateProductAsync();
            await PopulateMotorcyclesAsync();
            await PopulateServiceOrderAsync();
            await PopulateBuyAsync();
            await PopulateBillAsync();
            await PopulateRepairAsync();
            await PopulateServiceTypeAsync();
            await PopulateUserAsync();

            /*
            ORDEN PARA LA CREACIÓN:
            Clients
            Employees
            Products
            Motorcycles
            ServiceOrders
            Buys
            Bills
            Repairs
            ServiceTypes
            Users
            */


            //guardado en BD
            await _context.SaveChangesAsync();
        }
        #region Private Methos
        private async Task PopulateClientsAsync()
        {
            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Entities.Client
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 123456789,
                    FirstName = "Daniel",
                    LastName = "Higuita",
                    Phone = "3103103101",
                    Helmet = true,
                    Papers = true
                });
                _context.Clients.Add(new Entities.Client
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 987654321,
                    FirstName = "Estiven",
                    LastName = "David",
                    Phone = "3103103100",
                    Helmet = false,
                    Papers = false
                });
                _context.Clients.Add(new Entities.Client
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 987654321,
                    FirstName = "Pepito",
                    LastName = "Perez",
                    Phone = "3103103111",
                    Helmet = false,
                    Papers = true
                });
                _context.Clients.Add(new Entities.Client
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 987654321,
                    FirstName = "Juaquin Alberto",
                    LastName = "Restrepo Espinoza",
                    Phone = "3103103111",
                    Helmet = true,
                    Papers = false
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateEmployeeAsync()
        {
            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new Entities.Employee
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 1122334455,
                    FirstName = "Francisco",
                    LastName = "Perez",
                    Phone = "3103103102"
                });
                _context.Employees.Add(new Entities.Employee
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 1122334456,
                    FirstName = "Pedrito",
                    LastName = "Cardona",
                    Phone = "3103103104"
                });
                _context.Employees.Add(new Entities.Employee
                {
                    CreatedDate = DateTime.Now,
                    Cedula = 111222333,
                    FirstName = "Esmeralda",
                    LastName = "Espinoza Perez",
                    Phone = "3103103999"
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateProductAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync(e => e.Cedula == 123456789);
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Entities.Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del producto 1",
                    Stock = 50,
                    Price = 10000
                });
                _context.Products.Add(new Entities.Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del producto 2",
                    Stock = 100,
                    Price = 20000
                });
                _context.Products.Add(new Entities.Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del producto 3",
                    Stock = 150,
                    Price = 30000
                });
            }

            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateMotorcyclesAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync();
            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Motorcycles.Any())
            {
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA00",
                    Model = 2000,
                    Brand = "BMW",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA01",
                    Model = 2001,
                    Brand = "SUZUKI",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA02",
                    Model = 2002,
                    Brand = "YAMAHA",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA03",
                    Model = 2003,
                    Brand = "HONDA",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA04",
                    Model = 2004,
                    Brand = "Hero",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA05",
                    Model = 2005,
                    Brand = "Pulsar",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = null
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateServiceOrderAsync()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.ServiceOrders.Any())
            {
                _context.ServiceOrders.Add(new Entities.ServiceOrder
                {
                    CreatedDate = DateTime.Now,
                    Description = "Prueba de guardado del ServiceOrder 1",
                    EntryDate = DateTime.Now,
                    ExitDate = DateTime.Now,
                    EmployeeId = employee.Id,
                    BillId = null,
                    ServiceTypes = null,
                    Repairs = null
                });
                _context.ServiceOrders.Add(new Entities.ServiceOrder
                {
                    CreatedDate = DateTime.Now,
                    Description = "Prueba de guardado del ServiceOrder 2",
                    EntryDate = DateTime.Now,
                    ExitDate = DateTime.Now,
                    EmployeeId = employee.Id,
                    BillId = null,
                    ServiceTypes = null,
                    Repairs = null
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateBuyAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync();
            var product = await _context.Products.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Buys.Any())
            {
                _context.Buys.Add(new Buy
                {
                    CreatedDate = DateTime.Now,
                    ClientId = client.Id,
                    ProductId = product.Id
                });
                _context.Buys.Add(new Buy
                {
                    CreatedDate = DateTime.Now,
                    ClientId = client.Id,
                    ProductId = product.Id
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateBillAsync()
        {
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();
            var product = await _context.Products.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Bills.Any())
            {
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Quantity = 3,
                    ServiceOrderId = serviceOrder.Id,
                    ProductId = product.Id
                });
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Quantity = 2,
                    ServiceOrderId = serviceOrder.Id,
                    ProductId = product.Id
                });
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Quantity = 1,
                    ServiceOrderId = serviceOrder.Id,
                    ProductId = product.Id
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateRepairAsync()
        {
            var motorcycles = await _context.Motorcycles.FirstOrDefaultAsync();
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Repairs.Any())
            {
                _context.Repairs.Add(new Entities.Repair
                {
                    CreatedDate = DateTime.Now,
                    Detail = "Prueba de guardado del Seeder en repair 1",
                    Cost = 100000.00,
                    RepairDate = DateTime.Now,
                    MotorcyclesId = motorcycles.Id,
                    ServiceOrderId = serviceOrder.Id
                });
                _context.Repairs.Add(new Entities.Repair
                {
                    CreatedDate = DateTime.Now,
                    Detail = "Prueba de guardado del Seeder en repair 2",
                    Cost = 540000.00,
                    RepairDate = DateTime.Now,
                    MotorcyclesId = motorcycles.Id,
                    ServiceOrderId = serviceOrder.Id
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateServiceTypeAsync()
        {
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new ServiceType
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del servicio 1",
                    ServiceOrderId = serviceOrder.Id
                });
                _context.ServiceTypes.Add(new ServiceType
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del servicio 2",
                    ServiceOrderId = serviceOrder.Id
                });
                _context.ServiceTypes.Add(new ServiceType
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del servicio 3",
                    ServiceOrderId = serviceOrder.Id
                });
            }
            //guardado en BD
            await _context.SaveChangesAsync();
        }
        private async Task PopulateUserAsync()
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync();

                //El método Any() me indica si la tabla Clients tiene al menos un registro...
                //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
                if (!_context.Users.Any())
                {
                    _context.Users.Add(new User
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Pepito.Perez",
                        Role = "Admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        EmployeeId = employee.Id  // Asociar el EmployeeId con el ID del empleado
                    });
                    _context.Users.Add(new User
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Juaquin.Rodriguez",
                        Role = "Supervisor",
                        Password = BCrypt.Net.BCrypt.HashPassword("654321"),
                        EmployeeId = employee.Id  // Asociar el EmployeeId con el ID del empleado
                    });
                    _context.Users.Add(new User
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Ernesto.arbeloa",
                        Role = "Operación",
                        Password = BCrypt.Net.BCrypt.HashPassword("ernesto.arbeloa123"),
                        EmployeeId = employee.Id  // Asociar el EmployeeId con el ID del empleado
                    });
                }
                //guardado en BD
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion
    }
}
