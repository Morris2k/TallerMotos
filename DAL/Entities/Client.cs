using System.ComponentModel.DataAnnotations;

namespace TallerMotos.DAL.Entities
{
    public class Client : AuditBase
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

        [Display(Name = "Casco")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public bool Helmet { get; set; } // True si deja el casco, False si no

        [Display(Name = "Papeles")]
        [Required(ErrorMessage = "Los {0} son obligatorios")]
        public bool Papers { get; set; } // True si deja los papeles, False si no

        //Así es como relaciono 2 tablas con EF Core: buys
        [Display(Name = "compras")]
        public ICollection<Buy>? Buys { get; set; }

        //Así es como relaciono 2 tablas con EF Core: Motorcycles
        [Display(Name = "Motorcycles")]
        public ICollection<Motorcycles>? Motorcycless { get; set; }
    }
}
