using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteClasses.Models;

namespace TesteClasses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public UsuarioController(TesteClassesContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarioModel()
        {
            return await _context.UsuarioModel.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(int id)
        {
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return usuarioModel;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.IdUsuario)
            {
                return BadRequest();
            }

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

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
            _context.UsuarioModel.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.IdUsuario }, usuarioModel);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
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
