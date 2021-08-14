using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {
        }

        [Key]
        public Guid ClienteId { get; set; }
        public string TipoPessoa { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string VendedorResponsavel { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Pais { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string InformacoesAdicionais { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual UsuarioModel Usuario { get; set; }

    }
}
