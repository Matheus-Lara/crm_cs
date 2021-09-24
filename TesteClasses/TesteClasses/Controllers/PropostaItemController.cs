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
    public class PropostaItemController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public PropostaItemController(TesteClassesContext context)
        {
            _context = context;
        }

        // GET: api/PropostaItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropostaItemModel>>> GetPropostaItemModel()
        {
            return await _context.PropostaItemModel.ToListAsync();
        }

        // GET: api/PropostaItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropostaItemModel>> GetPropostaItemModel(int id)
        {
            var propostaItemModel = await _context.PropostaItemModel.FindAsync(id);

            if (propostaItemModel == null)
            {
                return NotFound();
            }

            return propostaItemModel;
        }

        // PUT: api/PropostaItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropostaItemModel(int id, PropostaItemModel propostaItemModel)
        {
            if (id != propostaItemModel.IdPropostaItem)
            {
                return BadRequest();
            }

            _context.Entry(propostaItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropostaItemModelExists(id))
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

        // POST: api/PropostaItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropostaItemModel>> PostPropostaItemModel(PropostaItemModel propostaItemModel)
        {
            _context.PropostaItemModel.Add(propostaItemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropostaItemModel", new { id = propostaItemModel.IdPropostaItem }, propostaItemModel);
        }

        // DELETE: api/PropostaItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropostaItemModel(int id)
        {
            var propostaItemModel = await _context.PropostaItemModel.FindAsync(id);
            if (propostaItemModel == null)
            {
                return NotFound();
            }

            _context.PropostaItemModel.Remove(propostaItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropostaItemModelExists(int id)
        {
            return _context.PropostaItemModel.Any(e => e.IdPropostaItem == id);
        }
    }
}
