using System;
using System.ComponentModel.DataAnnotations;

namespace TesteClasses.Models
{
    public class InteracoesModel
    {
        public InteracoesModel()
        {
        }

        [Key]
        public Guid IdInteracao { get; set; }

        public DateTime DataInteracao { get; set; }

        public string MeioContato { get; set; }

        public string Descricao { get; set; }

        public bool ClienteRespondeu { get; set; }
    }
}
