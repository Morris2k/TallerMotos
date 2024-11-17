using System.ComponentModel.DataAnnotations;

namespace TallerMotos.DAL.Entities
{
    public class AuditBase
    {
        [Key] // pk
        [Required] // obligatorio
        public virtual Guid Id { get; set; } // PK de las tablas
        public virtual DateTime? CreatedDate { get; set; } // guardar fecha de registro nuevo
        public virtual DateTime? ModifiedDate { get; set; } // guardar fecha de modificacion de registro

    }
}
