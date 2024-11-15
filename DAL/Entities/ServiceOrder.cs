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

        // Relación con Repair
        public virtual ICollection<Repair> Repairs { get; set; } = new List<Repair>();

        // Relación muchos a muchos con ServiceType
        public virtual ICollection<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();

        // Relación uno a uno con Bill
        public virtual Bill Bill { get; set; }  // Propiedad de navegación

        // Relación con Empleado: Cada orden de servicio tiene un empleado responsable
        public Guid EmployeeId { get; set; }  // Clave foránea a Empleado
        public virtual Employee Employee { get; set; } // Propiedad de navegación
    }
}
