using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Data;
using System.Numerics;
using TallerMotos.DAL.Entities;
using System.Diagnostics;

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
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateClientsAsync();
            await PopulateEmployeeAsync();
            await PopulateUserAsync();
            await PopulateProductAsync();
            await PopulateBuyAsync();
            await PopulateServiceOrderAsync();
            await PopulateBillAsync();
            await PopulateMotorcyclesAsync();
            await PopulateRepairAsync();
            await PopulatedServiceTypeAsync();

            await _context.SaveChangesAsync();
        }
        #region Private Methos
        private async Task PopulateClientsAsync()
        {
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
                        }
                    }
                });
            }
        }
        private async Task PopulateEmployeeAsync()
        {
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
                        Name = "Francisco.Perez1",
                        Role = "Admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    }
                });
            }
        }

        private async Task PopulateProductAsync()
        {
            Debug.WriteLine("Ejecutando PopulateProductAsync..."); // Verificar si se ejecuta

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Entities.Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Nombre del producto 1",
                    Stock = 100,
                    Price = 30000,
                });

                Debug.WriteLine("Producto agregado al contexto.");
            }
            else
            {
                Debug.WriteLine("Ya existen productos en la base de datos.");
            }
        }

        private async Task PopulateServiceOrderAsync()
        {
            if (!_context.ServiceOrders.Any())
            {
                _context.ServiceOrders.Add(new Entities.ServiceOrder
                {
                    CreatedDate = DateTime.Now,
                    Description = "Prueba de guardado del ServiceOrder",
                    EntryDate = DateTime.Now,
                    ExitDate = DateTime.Now.AddDays(5), 
                    Employee = new Employee() 
                    {
                        CreatedDate = DateTime.Now,
                        Cedula = 11223344,
                        FirstName = "Jose",
                        LastName = "Martinez",
                        Phone = "3103103234",
                        User = new User()
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Jose.Martinez1",
                            Role = "Admin",
                            Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        }
                    }

                });

                await _context.SaveChangesAsync();
                Debug.WriteLine("Orden de servicio creada exitosamente.");
            }
        }

        private async Task PopulateUserAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new Entities.User
                {
                    CreatedDate = DateTime.Now,
                    Name = "santiago.morales1",
                    Role = "Admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Employee = new Employee()
                    {
                        CreatedDate = DateTime.Now,
                        Cedula = 1017247226,
                        FirstName = "santiago",
                        LastName = "morales",
                        Phone = "3103103234",
                    }
                });
            }
        }

        private async Task PopulateBuyAsync()
        {
            if (!_context.Buys.Any())
            {
                _context.Buys.Add(new Entities.Buy
                {
                    CreatedDate = DateTime.Now,
                    Product = new Product()
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Nombre del producto 2",
                        Stock = 80,
                        Price = 35000,
                    },
                    Client = new Client()
                    {
                        CreatedDate = DateTime.Now,
                        Cedula = 123456789,
                        FirstName = "cristian",
                        LastName = "camilo",
                        Phone = "3108575645",
                        Helmet = true,
                        Papers = true,
                    }
                });

            }

        }

       private async Task PopulateBillAsync()
        {
            if (!_context.Bills.Any())
            {
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Total = 20000,
                    Quantity = 5,
                    Product = new Product()
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Nombre del producto 3",
                        Stock = 10,
                        Price = 870000,
                    },
                    ServiceOrder = new ServiceOrder()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Reparacion motor",
                        EntryDate = DateTime.Now,
                        ExitDate = DateTime.Now.AddDays(5),
                        Employee = new Employee()
                        {
                            CreatedDate = DateTime.Now,
                            Cedula = 1019876553,
                            FirstName = "andres",
                            LastName = "velasquez",
                            Phone = "3103103234",
                            User = new User()
                            {
                                CreatedDate = DateTime.Now,
                                Name = "andres.velasquez",
                                Role = "Admin",
                                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                            }
                        }
                    }
                });

            }

        }

        private async Task PopulateMotorcyclesAsync()
        {
            if (!_context.Motorcycles.Any())
            {
                _context.Motorcycles.Add(new Entities.Motorcycles
                {
                    CreatedDate = DateTime.Now,
                    Plate = "BBB111",
                    Model = 2020,
                    Brand = "Yamaha",
                    Milieage = 0,
                    Clients = new Client()
                    {
                        CreatedDate = DateTime.Now,
                        Cedula = 11224455,
                        FirstName = "camilo",
                        LastName = "osorio",
                        Phone = "3108575645",
                        Helmet = true,
                        Papers = true,
                    }
                });
            }
        }

        private async Task PopulateRepairAsync()
        {
            if (!_context.Repairs.Any())
            {
                _context.Repairs.Add(new Entities.Repair
                {
                    CreatedDate = DateTime.Now,
                    Detail = "Prueba de guardado del Seeder",
                    Cost = 100000.00,
                    RepairDate = DateTime.Now,
                    Motorcycle = new Motorcycles()
                    {
                        CreatedDate = DateTime.Now,
                        Plate = "CCC444",
                        Model = 2022,
                        Brand = "Suzuki",
                        Milieage = 0,
                        Clients = new Client()
                        {
                            CreatedDate = DateTime.Now,
                            Cedula = 22222222,
                            FirstName = "jhon",
                            LastName = "Alvarez",
                            Phone = "3140096871",
                            Helmet = true,
                            Papers = true,
                        }
                    },
                    ServiceOrder = new ServiceOrder()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Cambio filtro",
                        EntryDate = DateTime.Now,
                        ExitDate = DateTime.Now.AddDays(5),
                        Employee = new Employee()
                        {
                            CreatedDate = DateTime.Now,
                            Cedula = 333456765,
                            FirstName = "camilo",
                            LastName = "ocampo",
                            Phone = "3109874455",
                            User = new User()
                            {
                                CreatedDate = DateTime.Now,
                                Name = "camilo.ocampo",
                                Role = "Admin",
                                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                            }
                        }
                    }
                });
            }
        }

        private async Task PopulatedServiceTypeAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new Entities.ServiceType
                {
                    Name = "Motor",
                    ServiceOrder = new ServiceOrder()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Cambio llantas",
                        EntryDate = DateTime.Now,
                        ExitDate = DateTime.Now.AddDays(5),
                        Employee = new Employee()
                        {
                            CreatedDate = DateTime.Now,
                            Cedula = 1017885774,
                            FirstName = "mateo",
                            LastName = "morales",
                            Phone = "3109688877",
                            User = new User()
                            {
                                CreatedDate = DateTime.Now,
                                Name = "mateo.morales",
                                Role = "Admin",
                                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                            }
                        }
                    }
                });
            }
        }
        #endregion
    }
}
