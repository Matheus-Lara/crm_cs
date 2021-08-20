using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class PropostaItemModel
    { 

        [Key]
        public int IdPropostaItem { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal SubTotal { get; set; }

        public int IdProposta { get; set; }

        public int IdProduto { get; set; }

        [ForeignKey("IdProposta")]
        public virtual PropostaModel Proposta { get; set; }

        [ForeignKey("IdProduto")]
        public virtual ProdutoModel Produto { get; set; }


    }
}
