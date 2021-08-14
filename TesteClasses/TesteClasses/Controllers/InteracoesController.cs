using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteClasses.Models;

namespace TesteClasses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteracoesController : ControllerBase
    {

        [HttpGet]
        public IActionResult AdicionarInteracao(InteracoesModel model)
        {
            var dados = new InteracoesModel
            {
                DataInteracao = DateTime.UtcNow,
                ClienteRespondeu = model.ClienteRespondeu,
                Descricao = model.Descricao,
                MeioContato = model.MeioContato                
            };
            
            return Ok(dados);
        }
    }
}
