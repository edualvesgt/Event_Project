using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weapi.Event_.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]

        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria")]
        public string? Descricao { get; set; }


        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A Informacao de exibicao e obrigatoria")]
        public bool Exibe { get; set; }

        //referencia da tabela USUARIO 
        [Required(ErrorMessage = "Usuario Obrigatorio")]
        public Guid IdUsuario { get; set; }


        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //Referencia a tabela EVENTO 
        [Required(ErrorMessage = "Evento Obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
