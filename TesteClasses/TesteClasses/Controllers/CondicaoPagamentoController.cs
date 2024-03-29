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
    public class CondicaoPagamentoController : ControllerBase
    {
        private readonly TesteClassesContext _context;

        public CondicaoPagamentoController(TesteClassesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CondicaoPagamentoModel>>> GetCondicaoPagamentoModel()
        {
            return await _context.CondicaoPagamentoModel.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CondicaoPagamentoModel>> GetCondicaoPagamentoModel(int id)
        {
            var condicaoPagamentoModel = await _context.CondicaoPagamentoModel.FindAsync(id);

            if (condicaoPagamentoModel == null)
            {
                return NotFound();
            }

            return condicaoPagamentoModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicaoPagamentoModel(int id, CondicaoPagamentoModel condicaoPagamentoModel)
        {
            if (id != condicaoPagamentoModel.IdCp)
            {
                return BadRequest();
            }

            _context.Entry(condicaoPagamentoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicaoPagamentoModelExists(id))
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
        public async Task<ActionResult<CondicaoPagamentoModel>> PostCondicaoPagamentoModel(CondicaoPagamentoModel condicaoPagamentoModel)
        {
            _context.CondicaoPagamentoModel.Add(condicaoPagamentoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondicaoPagamentoModel", new { id = condicaoPagamentoModel.IdCp }, condicaoPagamentoModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondicaoPagamentoModel(int id)
        {
            var condicaoPagamentoModel = await _context.CondicaoPagamentoModel.FindAsync(id);
            if (condicaoPagamentoModel == null)
            {
                return NotFound();
            }

            _context.CondicaoPagamentoModel.Remove(condicaoPagamentoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondicaoPagamentoModelExists(int id)
        {
            return _context.CondicaoPagamentoModel.Any(e => e.IdCp == id);
        }
    }
}
