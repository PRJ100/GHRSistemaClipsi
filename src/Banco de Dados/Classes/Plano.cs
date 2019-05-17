using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_de_Dados.Classes
{
    [Table("planos")]
    public class Plano
    {
        [Key]
        public int codigo { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(100)]
        public string razao_social { get; set; }

        [StringLength(50)]
        public string cnpj { get; set; }

        [StringLength(50)]
        public string registro_ans { get; set; }
    }
}
