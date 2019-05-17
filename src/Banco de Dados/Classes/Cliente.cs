using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_de_Dados.Classes
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(16)]
        public string cpf { get; set; }

        [StringLength(16)]
        public string rg { get; set; }

        [StringLength(20)]
        public string telefone { get; set; }

        [Required]
        [StringLength(50)]
        public string sexo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string nascimento { get; set; }

        [StringLength(100)]
        public string bairro { get; set; }

        [StringLength(100)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string numero { get; set; }

        [StringLength(100)]
        public string cidade { get; set; }

        [StringLength(50)]
        public string cep { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        [StringLength(50)]
        public string ativo { get; set; }
    }
}



