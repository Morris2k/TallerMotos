using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class Repair : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Código autogenerado por la base de datos
        public int Code { get; set; } // Código único para la reparación

        [Display(Name = "Detalle de la reparación")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(500, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Detail { get; set; } // Descripción de la reparación

        [Display(Name = "Costo")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero")]
        public decimal Cost { get; set; } // Costo de la reparación

        [Display(Name = "Fecha de reparación")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        public DateTime RepairDate { get; set; } // Fecha en que se realizó la reparación
    }
}
