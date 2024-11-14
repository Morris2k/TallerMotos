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
    }
}
