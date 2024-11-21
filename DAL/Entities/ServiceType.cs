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

        //Así es como relaciono 2 tablas con EF Core: Repairs
        [Display(Name = "Repairs")]
        public Repair? Repairs { get; set; }

        //FK
        [Display(Name = "Id Repair")]
        public Guid RepairsId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Products
        
        [Display(Name = "Products")]
        public Product? Products { get; set; }

        //FK
        [Display(Name = "Id Product")]
        public Guid ProductsId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Buy
        [Display(Name = "Buy")]
        public Buy? Buy { get; set; }

        //FK
        [Display(Name = "Id Buy")]
        public Guid BuyId { get; set; }

        
        /*
        // Relación muchos a muchos con ServiceOrder
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();*/
    }
}

