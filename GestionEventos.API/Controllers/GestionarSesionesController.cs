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
    public class GestionarSesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GestionarSesionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GestionarSesiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GestionarSesiones>>> GetGestionarSesiones()
        {
            var data = await _context.GestionarSesiones
            .Include(s => s.Evento)
            .ToListAsync();

            return data;
        }

        // GET: api/GestionarSesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GestionarSesiones>> GetGestionarSesiones(int id)
        {
            var gestionarSesiones = await _context.GestionarSesiones.FindAsync(id);

            if (gestionarSesiones == null)
            {
                return NotFound();
            }

            return gestionarSesiones;
        }

        // PUT: api/GestionarSesiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestionarSesiones(int id, GestionarSesiones gestionarSesiones)
        {
            if (id != gestionarSesiones.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(gestionarSesiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestionarSesionesExists(id))
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

        // POST: api/GestionarSesiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GestionarSesiones>> PostGestionarSesiones(GestionarSesiones gestionarSesiones)
        {
            _context.GestionarSesiones.Add(gestionarSesiones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestionarSesiones", new { id = gestionarSesiones.Codigo }, gestionarSesiones);
        }

        // DELETE: api/GestionarSesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestionarSesiones(int id)
        {
            var gestionarSesiones = await _context.GestionarSesiones.FindAsync(id);
            if (gestionarSesiones == null)
            {
                return NotFound();
            }

            _context.GestionarSesiones.Remove(gestionarSesiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestionarSesionesExists(int id)
        {
            return _context.GestionarSesiones.Any(e => e.Codigo == id);
        }
    }
}
