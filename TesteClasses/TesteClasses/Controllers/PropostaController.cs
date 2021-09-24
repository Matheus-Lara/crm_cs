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
    public class PropostaController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public PropostaController(TesteClassesContext context)
        {
            _context = context;
        }

        // GET: api/Proposta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropostaModel>>> GetPropostaModel()
        {
            return await _context.PropostaModel.ToListAsync();
        }

        // GET: api/Proposta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropostaModel>> GetPropostaModel(int id)
        {
            var propostaModel = await _context.PropostaModel.FindAsync(id);

            if (propostaModel == null)
            {
                return NotFound();
            }

            return propostaModel;
        }

        // PUT: api/Proposta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropostaModel(int id, PropostaModel propostaModel)
        {
            if (id != propostaModel.IdProposta)
            {
                return BadRequest();
            }

            _context.Entry(propostaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropostaModelExists(id))
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

        // POST: api/Proposta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropostaModel>> PostPropostaModel(PropostaModel propostaModel)
        {
            _context.PropostaModel.Add(propostaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropostaModel", new { id = propostaModel.IdProposta }, propostaModel);
        }

        // DELETE: api/Proposta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropostaModel(int id)
        {
            var propostaModel = await _context.PropostaModel.FindAsync(id);
            if (propostaModel == null)
            {
                return NotFound();
            }

            _context.PropostaModel.Remove(propostaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropostaModelExists(int id)
        {
            return _context.PropostaModel.Any(e => e.IdProposta == id);
        }
    }
}
