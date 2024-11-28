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
        public double Total { get; set; } // Campo calculado, no debe ser asignado directamente, le quitaré el private para hacer pruebas...DanielHiugita

        [Display(Name = "Cantidad de productos")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Quantity { get; set; }

        //Así es como relaciono 2 tablas con EF Core: ServiceOrder
        [Display(Name = "ServiceOrder")]
        public ServiceOrder? ServiceOrder { get; set; }
        //FK
        [Display(Name = "Id ServiceOrder")]
        public Guid ServiceOrderId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Product
        [Display(Name = "Product")]
        public Product? Product { get; set; }
        //FK
        [Display(Name = "Id Product")]
        public Guid? ProductId { get; set; }
    }
}
