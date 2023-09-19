using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weapi.Event_.Domains
{
    [Table(nameof(TipoEvento))]
    public class TipoEvento
    {
        [Key]

        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Tipo do evento Obrigatorio")]
        public string? Titulo { get; set; }

    }
}
