using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClasses.Models
{
    public class ClienteModel
    { 

        [Key]
        public int IdCliente { get; set; }

        public bool PessoaJuridica { get; set; }

        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public int VendedorResponsavel { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Pais { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string InformacoesAdicionais { get; set; }

        [ForeignKey("VendedorResponsavel")]
        public virtual UsuarioModel Usuario { get; set; }

    }
}
