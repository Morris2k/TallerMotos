using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class ServiceType : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Código autogenerado por la base de datos
        public int Code { get; set; } // Código único para el tipo de servicio

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Name { get; set; } // Nombre del tipo de servicio

        //Así es como relaciono 2 tablas con EF Core: ServiceOrder
        [Display(Name = "ServiceOrder")]
        public ServiceOrder? ServiceOrder { get; set; }
        //FK
        [Display(Name = "Id ServiceOrder")]
        public Guid ServiceOrderId { get; set; }

    }
}

