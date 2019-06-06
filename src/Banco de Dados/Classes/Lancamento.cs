using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banco_de_Dados.Classes
{
    [Table("lancamentos")]
    public class Lancamento
    {
        [Key]
        public int codigo { get; set; }
        [StringLength(10)]
        public string tipo { get; set; }
        [StringLength(10)]
        public string data { get; set; }
        [StringLength(200)]
        public string descricao { get; set; }
        [StringLength(18)]
        public string forma_pagamento { get; set; }
        public decimal valor { get; set; }
        public int mes { get; set; }
    }
}
