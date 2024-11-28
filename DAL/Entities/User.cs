using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMotos.DAL.Entities
{
    public class User : AuditBase
    {
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Código autogenerado por la base de datos
        public int Code { get; set; } // Código único para el usuario

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Name { get; set; } // Nombre del usuario

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El {0} tiene un máximo de {1} caracteres")]
        public string Role { get; set; } // Rol del usuario (por ejemplo, "Administrador", "Técnico")

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [MinLength(6, ErrorMessage = "La {0} debe tener al menos {1} caracteres")]
        public string Password { get; set; } // Contraseña del usuario (asegúrate de encriptarla)

        //Así es como relaciono 2 tablas con EF Core: Employee
        [Display(Name = "Employee")]
        public Employee? Employee { get; set; }
        //FK
        [Display(Name = "Id Employee")]
        public Guid EmployeeId { get; set; }
    }
}
