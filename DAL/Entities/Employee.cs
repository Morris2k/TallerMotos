using System.ComponentModel.DataAnnotations;

namespace TallerMotos.DAL.Entities
{
    public class Employee : AuditBase
    {
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(1, 9999999999, ErrorMessage = "La {0} debe tener hasta 10 dígitos")]
        public int Cedula { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "Los {0} tienen un máximo de {1} caracteres")]
        [Required(ErrorMessage = "Los {0} son obligatorios")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "Los {0} tienen un máximo de {1} caracteres")]
        [Required(ErrorMessage = "Los {0} son obligatorios")]
        public string LastName { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(15, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Phone { get; set; }

        /* // Relación uno a muchos con ServiceOrder
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

        // Propiedad de clave foránea hacia User
        public Guid UserId { get; set; }  // Este es el FK */
    }
}
