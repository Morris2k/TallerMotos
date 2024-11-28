using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class ServiceOrder : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Código autogenerado por la base de datos
        public int Code { get; set; } // Código único para la orden de servicio

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [MaxLength(500, ErrorMessage = "La {0} tiene un máximo de {1} caracteres")]
        public string Description { get; set; } // Descripción del servicio solicitado

        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        public DateTime EntryDate { get; set; } // Fecha en que se ingresó la moto al taller

        [Display(Name = "Fecha de Salida")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        public DateTime ExitDate { get; set; } // Fecha en que se retiró la moto del taller

        //Así es como relaciono 2 tablas con EF Core: Bill
        [Display(Name = "Bill")]
        public Bill? Bill { get; set; }
        //FK
        [Display(Name = "Id Bill")]
        public Guid BillId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Employee
        [Display(Name = "Employee")]
        public Employee? Employee { get; set; }
        //FK
        [Display(Name = "Id Employee")]
        public Guid EmployeeId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: ServiceTypes
        [Display(Name = "ServiceTypes")]
        public ICollection<ServiceType>? ServiceTypes { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Repairs
        [Display(Name = "Repairs")]
        public ICollection<Repair>? Repairs { get; set; }

    }
}
