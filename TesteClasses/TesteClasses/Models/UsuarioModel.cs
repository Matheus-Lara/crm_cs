using System;
using System.ComponentModel.DataAnnotations;

namespace TesteClasses
{
    public class UsuarioModel
    {
        [Key]
        public Guid IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public bool Vendedor { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
