using System.ComponentModel.DataAnnotations;

namespace TallerMotos.DAL.Entities
{
    public class Motorcycles : AuditBase
    {
        [Display(Name = "Placa")]
        [MaxLength(6, ErrorMessage = "La {0} tiene un maximo de {1} caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Plate { get; set; }

        [Display(Name = "Modelo")]
        [Range(1900, 2100, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public int Model { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Brand { get; set; }

        [Display(Name = "Kilometraje")]
        [Range(0, 99999999, ErrorMessage = "El {0} tiene un valor máximo de {1}")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public int Milieage { get; set; }
    }
}
