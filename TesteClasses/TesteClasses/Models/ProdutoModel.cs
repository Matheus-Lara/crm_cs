using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class ProdutoModel
    {

        [Key]
        public int IdProduto { get; set; }

        public bool Servico { get; set; }

        public string CodigoProduto { get; set; }

        public string UnidadeMedida { get; set; }

        public bool Habilitado { get; set; }

        public decimal PrecoVenda { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
