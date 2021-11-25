using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteClasses.Models;
using C = TesteClasses.Constants;
using Microsoft.AspNetCore.Authorization;

namespace TesteClasses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class InteracoesController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public InteracoesController(TesteClassesContext context)
        {
            _context = context;
        }

        // GET: api/Interacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteracoesModel>>> GetInteracoesModel()
        {
            return await _context.InteracoesModel.ToListAsync();
        }

        // GET: api/Interacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InteracoesModel>> GetInteracoesModel(int id)
        {
            var interacoesModel = await _context.InteracoesModel.FindAsync(id);

            if (interacoesModel == null)
            {
                return NotFound();
            }

            return interacoesModel;
        }

        // PUT: api/Interacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteracoesModel(int id, InteracoesModel interacoesModel)
        {
            if (id != interacoesModel.IdInteracao)
            {
                return BadRequest();
            }

            _context.Entry(interacoesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteracoesModelExists(id))
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

        // POST: api/Interacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InteracoesModel>> PostInteracoesModel(InteracoesModel interacoesModel)
        {
            _context.InteracoesModel.Add(interacoesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInteracoesModel", new { id = interacoesModel.IdInteracao }, interacoesModel);
        }

        // DELETE: api/Interacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInteracoesModel(int id)
        {
            var interacoesModel = await _context.InteracoesModel.FindAsync(id);
            if (interacoesModel == null)
            {
                return NotFound();
            }

            _context.InteracoesModel.Remove(interacoesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InteracoesModelExists(int id)
        {
            return _context.InteracoesModel.Any(e => e.IdInteracao == id);
        }
    }
}
