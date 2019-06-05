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
        public string tipo { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }
        public string forma_pagamento { get; set; }
        public decimal valor { get; set; }
    }
}
