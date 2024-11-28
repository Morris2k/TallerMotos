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
            await PopulateUserAsync();
            //await PopulateProductAsync();
            await PopulateBuyAsync();
            //await PopulateBillAsync();
            //await PopulateServiceOrderAsync();
            //await PopulateMotorcyclesAsync();
            //await PopulateRepairAsync();


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
                    Papers = false,
                    Motorcycless = new List<Motorcycles>()
                    {
                        new Motorcycles
                        {
                            CreatedDate = DateTime.Now,
                            Plate = "AAA00",
                            Model = 2000,
                            Brand = "Pulsar",
                            Milieage = 100000,
                        },
                        new Motorcycles
                        {
                            CreatedDate = DateTime.Now,
                            Plate = "AAA01",
                            Model = 2001,
                            Brand = "BWS-FI",
                            Milieage = 200000,
                        },
                        new Motorcycles
                        {
                            CreatedDate = DateTime.Now,
                            Plate = "AAA02",
                            Model = 2002,
                            Brand = "XTZ-250",
                            Milieage = 500000,
                        }
                    }
                });
            }
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
                    Cedula = 123456788,
                    FirstName = "Francisco",
                    LastName = "Perez",
                    Phone = "3103103102",
                    User = new User()
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Pepito.Perez",
                        Role = "Admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    }
                });
            }
        }
        private async Task PopulateUserAsync()
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Cedula == 123456789);

                //El método Any() me indica si la tabla Clients tiene al menos un registro...
                //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
                if (!_context.Users.Any())
                {
                    if (employee != null)
                    {

                        // Crear un nuevo usuario y asignar el EmployeeId
                        var user = new Entities.User
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Pepito.Perez",
                            Role = "Admin",
                            
                            Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                            EmployeeId = employee.Id  // Asociar el EmployeeId con el ID del empleado
                        };
                        
                        // Añadir el usuario al contexto
                        _context.Users.Add(user);

                        employee.UserId = user.Id;

                        _context.Employees.Update(employee);   //virtualizo el objeto
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private async Task PopulateProductAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync(e => e.Cedula == 123456789);
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();
            if (_context.Products.Any())
            {
                _context.Products.Add(new Entities.Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del producto 1",
                    Stock = 100,
                    Price = 30000,
                    Buys = new List<Buy>()
                    {
                        new Buy
                        {
                            ClientId = client.Id
                        }
                    },
                    Bills = new List<Bill>()
                    {
                        new Bill
                        {
                            Total = 20000,
                            Quantity = 5,
                            ServiceOrderId = serviceOrder?.Id ?? Guid.NewGuid()

                        }
                    }
                });
            }
        }
        private async Task PopulateBuyAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync();
            var product = await _context.Products.FirstOrDefaultAsync();
            if (_context.Buys.Any())
            {
                _context.Buys.Add(new Buy
                {
                    CreatedDate = DateTime.Now,
                    ClientId = client?.Id ?? Guid.NewGuid(),
                    ProductId = product?.Id ?? Guid.NewGuid()
                });

            }

        }
        private async Task PopulateBillAsync()
        {
            var product = await _context.Products.FirstOrDefaultAsync();
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync();
            if (_context.Bills.Any())
            {
                _context.Bills.Add(new Bill
                {
                    CreatedDate = DateTime.Now,
                    Total = 20000,
                    Quantity = 5,
                    ProductId = product?.Id ?? Guid.NewGuid(),
                    ServiceOrderId = serviceOrder?.Id ?? Guid.NewGuid()

                });

            }

        }
        private async Task PopulateMotorcyclesAsync()
        {
            var client = await _context.Clients.FirstOrDefaultAsync(e => e.Cedula == 123456789);

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (_context.Motorcycles.Any())
            {
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "AAA03",
                    Model = 2003,
                    Brand = "Hero",
                    Milieage = 0,
                    ClientId = client.Id,
                    Repairs = new List<Repair>()
                    {
                        new Repair
                        {
                            CreatedDate = DateTime.Now,
                            Detail = "Prueba de guardado del Seeder",
                            Cost = 100000.00,
                            RepairDate = DateTime.Now,
                            ServiceOrderId = Guid.Empty
                        },
                        new Repair
                        {
                            CreatedDate = DateTime.Now,
                            Detail = "Prueba de guardado del Seeder",
                            Cost = 230000.00,
                            RepairDate = DateTime.Now,
                            ServiceOrderId = Guid.Empty
                        }
                    }
                });
            }
        }
        private async Task PopulateRepairAsync()
        {
            var motorcycles = await _context.Motorcycles.FirstOrDefaultAsync(e => e.Plate == "AAA00");
            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Repairs.Any())
            {
                _context.Repairs.Add(new Entities.Repair
                {
                    CreatedDate = DateTime.Now,
                    Detail = "Prueba de guardado del Seeder",
                    Cost = 100000.00,
                    RepairDate = DateTime.Now,
                    MotorcyclesId = motorcycles.Id,
                    ServiceOrderId = Guid.Empty
                });
            }
        }
        /*private async Task PopulateBillAsync()
        {
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync(so => so.Id == 000);
            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.Bills.Any())
            {
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Total = 30000,
                    Quantity = 3,
                    LastName = "Perez",
                    Phone = "3103103102",
                });
            }
        }
        */
        private async Task PopulateServiceOrderAsync()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Cedula == 123456789);
            var motorcycles = await _context.Motorcycles.FirstOrDefaultAsync(e => e.Plate == "AAA00");
            var bill = await _context.Bills.FirstOrDefaultAsync();

            //El método Any() me indica si la tabla Clients tiene al menos un registro...
            //El método Any() negado (!) me indica que no hay absolutamente nada en la tabla Clients...
            if (!_context.ServiceOrders.Any())
            {
                _context.ServiceOrders.Add(new Entities.ServiceOrder
                {
                    CreatedDate = DateTime.Now,
                    Description = "Prueba de guardado del ServiceOrder",
                    EntryDate = DateTime.Now,
                    ExitDate = DateTime.Now,
                    BillId = bill?.Id ?? Guid.NewGuid(), // Usa un ID válido o un GUID nuevo para pruebas
                    EmployeeId = employee?.Id ?? Guid.NewGuid(),
                    Repairs = new List<Repair>()
                    {
                        new Repair
                        {
                            CreatedDate = DateTime.Now,
                            Detail = "Prueba de guardado del Seeder para el repair",
                            Cost = 100000.00,
                            RepairDate = DateTime.Now,
                            MotorcyclesId = motorcycles?.Id ?? Guid.NewGuid()
                        }
                    },
                    ServiceTypes = new List<ServiceType>()
                    {
                        new ServiceType
                        {
                            Name = "Nombre del tipo de servicio1"
                        },
                        new ServiceType
                        {
                            Name = "Nombre del tipo de servicio2"
                        },
                        new ServiceType
                        {
                            Name = "Nombre del tipo de servicio3"
                        }
                    }
                });
            }
        }



        #endregion
    }
}
