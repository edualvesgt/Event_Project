using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weapi.Event_.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]

        [Required (ErrorMessage = "Titulo do tipo usuario Obrigatorio !")]
        public string? Titulo { get; set; }
    }

}
