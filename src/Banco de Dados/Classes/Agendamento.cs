using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banco_de_Dados.Classes
{
    [Table("agendamentos")]
    public class Agendamento
    {
        [Key]
        public int codigo { get; set; }

        public int? medico { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        [StringLength(10)]
        public string data { get; set; }

        [StringLength(7)]
        public string horario { get; set; }

        [StringLength(10)]
        public string paciente { get; set; }

        [StringLength(50)]
        public string convenio { get; set; }
    }
}
