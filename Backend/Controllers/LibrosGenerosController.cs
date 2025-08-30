using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContex;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosGenerosController : ControllerBase
    {
        private readonly BiblioContext _context;

        public LibrosGenerosController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/LibrosGeneros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroGenero>>> GetLibroGeneros()
        {
            return await _context.LibroGeneros.ToListAsync();
        }

        // GET: api/LibrosGeneros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroGenero>> GetLibroGenero(int id)
        {
            var libroGenero = await _context.LibroGeneros.FindAsync(id);

            if (libroGenero == null)
            {
                return NotFound();
            }

            return libroGenero;
        }

        // PUT: api/LibrosGeneros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroGenero(int id, LibroGenero libroGenero)
        {
            if (id != libroGenero.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroGenero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroGeneroExists(id))
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

        // POST: api/LibrosGeneros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroGenero>> PostLibroGenero(LibroGenero libroGenero)
        {
            _context.LibroGeneros.Add(libroGenero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibroGenero", new { id = libroGenero.Id }, libroGenero);
        }

        // DELETE: api/LibrosGeneros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroGenero(int id)
        {
            var libroGenero = await _context.LibroGeneros.FindAsync(id);
            if (libroGenero == null)
            {
                return NotFound();
            }

            _context.LibroGeneros.Remove(libroGenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroGeneroExists(int id)
        {
            return _context.LibroGeneros.Any(e => e.Id == id);
        }
    }
}
