using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class Product : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // El código se autogenera
        public int Code { get; set; } // Código único generado automáticamente

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Name { get; set; } // Nombre del producto

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El {0} no puede ser negativo")]
        public int Stock { get; set; } // Cantidad de producto disponible en inventario

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero")]
        public double Price { get; set; } // Precio del producto

        //Así es como relaciono 2 tablas con EF Core: Buys-Prodcuts
        [Display(Name = "Buys")]
        public ICollection<Buy>? Buys { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Bill-Prodcuts
        [Display(Name = "Bills")]
        public ICollection<Bill>? Bills { get; set; }

    }
}
