using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteClasses.Models;
using TesteClasses.Services;
using C = TesteClasses.Constants;
using Microsoft.AspNetCore.Authorization;

namespace TesteClasses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public UsuarioController(TesteClassesContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Login([FromBody]Credencial credencial)
        {
            UsuarioModel usuario = _context.UsuarioModel.SingleOrDefault(u => u.Login == credencial.Login);

            if (usuario == null || !SenhaService.CompararHash(credencial.Senha, usuario.Senha)) {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            string token = TokenService.GerarToken(usuario);

            usuario.Senha = null;

            return new {
                usuario = usuario,
                token = token
            };
        }

        [HttpGet]
        // [Authorize(Roles = C.ADMIN)]
        public ActionResult<IEnumerable<UsuarioModel>> GetUsuarioModel()
        {
            var listUsers = _context.UsuarioModel.ToList();

            for (int i = 0; i < listUsers.Count; i++)
            {
                listUsers[i].Senha = null;
            }

            return listUsers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(int id)
        {
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            usuarioModel.Senha = null;

            return usuarioModel;
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = C.ADMIN)]
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.IdUsuario)
            {
                return BadRequest();
            }

            string passwordHash = SenhaService.GerarHash(usuarioModel.Senha);
            usuarioModel.Senha = passwordHash;

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Route("AtualizarCredenciais/{id}")]
        [HttpPut]
        public async Task<IActionResult> AtualizarCredenciais(int id, [FromBody] UpdateCredencial credencial)
        {
            UsuarioModel usuario = _context.UsuarioModel.SingleOrDefault(u => u.Login == credencial.Login);

            if (usuario == null || !SenhaService.CompararHash(credencial.SenhaAtual, usuario.Senha)) {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            usuario.Senha = SenhaService.GerarHash(credencial.NovaSenha);
            
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();     
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
            string passwordHash = SenhaService.GerarHash(usuarioModel.Senha);
            usuarioModel.Senha = passwordHash;

            _context.UsuarioModel.Add(usuarioModel);
            await _context.SaveChangesAsync();

            usuarioModel.Senha = null;

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.IdUsuario }, usuarioModel);
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = C.ADMIN)]
        public async Task<IActionResult> DeleteUsuarioModel(int id)
        {
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.IdUsuario == id);
        }
    }
}
