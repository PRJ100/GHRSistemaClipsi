using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banco_de_Dados.Classes
{
    [Table("medicamentos")]
    public class Medicamento
    {
        [Key]
        public int codigo { get; set; }
        public int numeroRegistroMinisterio { get; set; }
        [StringLength(100)]
        public string nomeMedicamento { get; set; }
        [StringLength(200)]
        public string descricao { get; set; }
        [StringLength(10)]
        public string unidadeMedida { get; set; }

    }
}
