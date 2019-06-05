using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banco_de_Dados.Classes
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int codigo { get; set; }

        [Column("usuario")]
        [StringLength(50)]
        public string usuario1 { get; set; }

        [StringLength(40)]
        public string senha { get; set; }

        public int? nivel_acesso { get; set; }
    }
}
