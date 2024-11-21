using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class Buy : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; } // Código único, generado automáticamente

        [Display(Name = "Fecha de compra")]
        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.Now; // Fecha asignada automáticamente

        //Así es como relaciono 2 tablas con EF Core: Client
        [Display(Name = "Client")]
        public Client? Client { get; set; }

        //FK
        [Display(Name = "Id Client")]
        public Guid ClientId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Employee
        [Display(Name = "Employee")]
        public Employee? Employees { get; set; }

        //FK
        [Display(Name = "Id Employee")]
        public Guid EmployeeId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Bill
        [Display(Name = "Bill")]
        public Bill? Bills { get; set; }

        //FK
        [Display(Name = "Id Bill")]
        public Guid BillId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: ServiceType
        [Display(Name = "ServiceType")]
        public ICollection<ServiceType>? ServiceTypes { get; set; }

        //Así es como relaciono 2 tablas con EF Core: ServiceOrder
        [Display(Name = "ServiceOrder")]
        public ServiceOrder? ServiceOrder { get; set; }

        //FK
        [Display(Name = "Id ServiceOrder")]
        public Guid ServiceOrderId { get; set; }

        /*
        // Relación con Client
        public int ClientId { get; set; } // Clave foránea
        public virtual Client Client { get; set; } // Propiedad de navegación

        // Relación con Product
        public Guid ProductId { get; set; } // Clave foránea
        public virtual Product Product { get; set; } // Propiedad de navegación*/
    }
}
