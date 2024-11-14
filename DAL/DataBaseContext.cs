using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL.Entities;

namespace TallerMotos.DAL
{
    public class DataBaseContext : DbContext
    {
        // conexion a la base de datos por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }



        #region DbSets

        public DbSet<Motorcycles> Motorcycles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion
    }
}
