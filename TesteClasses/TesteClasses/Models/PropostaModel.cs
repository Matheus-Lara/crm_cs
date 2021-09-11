using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class PropostaModel
    { 

        [Key]
        public int IdProposta { get; set; }

        public int Status { get; set; }

        public int QtdeDiasPrimeiraParcela { get; set; }

        public int QtdeParcelas { get; set; }

        public string AssinaturaProposta { get; set; }

        public string Obs { get; set; }

        public int IdCp { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCp")]
        public virtual CondicaoPagamentoModel CondicaoPagamento { get; set; }

        [ForeignKey("IdCliente")]
        public virtual ClienteModel Cliente { get; set; }
    }
}
