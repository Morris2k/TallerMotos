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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.ServiceOrder)   // Bill tiene una ServiceOrder
                .WithOne(so => so.Bill)        // ServiceOrder tiene una Bill
                .HasForeignKey<ServiceOrder>(so => so.BillId); // Configura la clave foránea en ServiceOrder
            
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)         // Employee tiene un User
                .WithOne(u => u.Employee)    // User tiene un Employee
                .HasForeignKey<Employee>(e => e.UserId); // Configura la clave foránea en Employee

            modelBuilder.Entity<User>()
                .HasOne(e => e.Employee) // User tiene un Employee 
                .WithOne(u => u.User)    // Employee tiene un User
                .HasForeignKey<User>(e => e.EmployeeId); // Configura la clave foránea en User

            modelBuilder.Entity<ServiceOrder>()
                .HasOne(s => s.Bill)
                .WithOne(b => b.ServiceOrder)
                .HasForeignKey<Bill>(b => b.ServiceOrderId);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId);
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
