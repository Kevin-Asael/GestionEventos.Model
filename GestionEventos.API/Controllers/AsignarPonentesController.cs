using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventos.Model;

namespace GestionEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignarPonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignarPonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AsignarPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignarPonente>>> GetAsignarPonente()
        {
            var data = await _context.AsignarPonentes
             .Include(a => a.Ponente)
             .Include(a => a.Evento)
             .ToListAsync();

            return data;
        }

        // GET: api/AsignarPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignarPonente>> GetAsignarPonente(int id)
        {
            var asignarPonente = await _context.AsignarPonentes.FindAsync(id);

            if (asignarPonente == null)
            {
                return NotFound();
            }

            return asignarPonente;
        }

        // PUT: api/AsignarPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignarPonente(int id, AsignarPonente asignarPonente)
        {
            if (id != asignarPonente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(asignarPonente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignarPonenteExists(id))
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

        // POST: api/AsignarPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignarPonente>> PostAsignarPonente(AsignarPonente asignarPonente)
        {
            _context.AsignarPonentes.Add(asignarPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignarPonente", new { id = asignarPonente.Codigo }, asignarPonente);
        }

        // DELETE: api/AsignarPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignarPonente(int id)
        {
            var asignarPonente = await _context.AsignarPonentes.FindAsync(id);
            if (asignarPonente == null)
            {
                return NotFound();
            }

            _context.AsignarPonentes.Remove(asignarPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignarPonenteExists(int id)
        {
            return _context.AsignarPonentes.Any(e => e.Codigo == id);
        }
    }
}
