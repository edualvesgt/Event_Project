using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weapi.Event_.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]

        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage = "Situacao da presenca obrigatoria")]
        public bool Situacao { get; set; }

        //referencia da tabela USUARIO 
        [Required(ErrorMessage = "Usuario Obrigatorio")]
        public Guid IdUsuario { get; set; }


        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //REferencia a tabela EVENTO 
        [Required(ErrorMessage = "Evento Obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }

    }
}
