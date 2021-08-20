using System;
using System.ComponentModel.DataAnnotations;

namespace TesteClasses.Models
{
    public class CondicaoPagamentoModel
    {
        [Key]
        public int IdCp { get; set; }

        public string Descricao { get; set; }

        public int QtdePadraoDias { get; set; }

        public int QtdePadraoParcelas { get; set; }

        public bool Habilitado { get; set; }
    }
}
