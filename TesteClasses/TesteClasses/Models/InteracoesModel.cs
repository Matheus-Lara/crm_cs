using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class InteracoesModel
    {

        [Key]
        public int IdInteracao { get; set; }

        public int IdCliente { get; set; }

        public int IdVendedor { get; set; }

        public DateTime DataInteracao { get; set; }

        public string MeioContato { get; set; }

        public string Descricao { get; set; }

        public bool ClienteRespondeu { get; set; }

        [ForeignKey("IdVendedor")]
        public virtual UsuarioModel Usuario { get; set; }

        [ForeignKey("IdCliente")]
        public virtual ClienteModel Cliente { get; set; }
    }
}
