using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_de_Dados.Classes
{
    [Table("lancamentos")]
    public class Lancamento
    {
        [Key]
        public int codigo { get; set; }
        public string tipo { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }
        public string forma_pagamento { get; set; }
        public Nullable<double> valor
        {
            get; set;
        }
    }
}
