using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banco_de_Dados.Classes
{
    [Table("medico")]
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int crm { get; set; }

        [StringLength(100)]
        public string especialidade { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(20)]
        public string telefone { get; set; }
    }
}
