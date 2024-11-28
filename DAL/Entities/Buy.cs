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

        //Así es como relaciono 2 tablas con EF Core: Product
        [Display(Name = "Product")]
        public Product? Product { get; set; }
        //FK
        [Display(Name = "Id Product")]
        public Guid? ProductId { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Client
        [Display(Name = "Client")]
        public Client? Client { get; set; }
        //FK
        [Display(Name = "Id Client")]
        public Guid? ClientId { get; set; }

    }
}
