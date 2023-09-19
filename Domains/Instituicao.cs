using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace weapi.Event_.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ Obrigatotio")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereco Obrigatotio")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereco Obrigatotio")]
        public string? NomeFantasia { get; set; }

    }
}
