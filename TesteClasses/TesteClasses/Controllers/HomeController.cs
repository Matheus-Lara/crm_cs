using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using C = TesteClasses.Constants;
using Microsoft.AspNetCore.Authorization;

namespace TesteClasses.Controllers
{
    [ApiController]
    [Route("")]
    // [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("bem vindo à api do CRM");
        }
    }
}
