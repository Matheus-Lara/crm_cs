using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TesteClasses.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
       [HttpPost, Route("login")]
        public IActionResult Login()
        {

            return Ok();
        }
    }
}
