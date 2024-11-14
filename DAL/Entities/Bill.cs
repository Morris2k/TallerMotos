using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class Bill : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; } // Código único, generado automáticamente

        [Display(Name = "Total")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Total { get; private set; } // Campo calculado, no debe ser asignado directamente

        [Display(Name = "Cantidad de productos")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Quantity { get; set; }
    }
}
