using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weapi.Event_.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuario Obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuario Obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha do usuario Obrigatorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Senha deve Conter de 6 a 100 caracteres")]
        public string? Senha { get; set; }

        //Referencia da tabela tipo usuario

        [Required(ErrorMessage = "Informe o Tipo Do usuario")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }

    }

}
