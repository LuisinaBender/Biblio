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
    public class LibrosAutoresController : ControllerBase
    {
        private readonly BiblioContext _context;

        public LibrosAutoresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/LibrosAutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroAutor>>> GetLibroAutores()
        {
            return await _context.LibroAutores.ToListAsync();
        }

        // GET: api/LibrosAutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroAutor>> GetLibroAutor(int id)
        {
            var libroAutor = await _context.LibroAutores.FindAsync(id);

            if (libroAutor == null)
            {
                return NotFound();
            }

            return libroAutor;
        }

        // PUT: api/LibrosAutores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroAutor(int id, LibroAutor libroAutor)
        {
            if (id != libroAutor.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroAutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroAutorExists(id))
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

        // POST: api/LibrosAutores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroAutor>> PostLibroAutor(LibroAutor libroAutor)
        {
            _context.LibroAutores.Add(libroAutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibroAutor", new { id = libroAutor.Id }, libroAutor);
        }

        // DELETE: api/LibrosAutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroAutor(int id)
        {
            var libroAutor = await _context.LibroAutores.FindAsync(id);
            if (libroAutor == null)
            {
                return NotFound();
            }

            _context.LibroAutores.Remove(libroAutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroAutorExists(int id)
        {
            return _context.LibroAutores.Any(e => e.Id == id);
        }
    }
}
