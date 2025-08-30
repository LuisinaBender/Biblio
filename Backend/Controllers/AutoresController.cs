using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContex;
using Service;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly BiblioContext _context;

        public AutoresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores([FromQuery] string filtro = "")
        {
            return await _context.Autores.AsNoTracking().Where(a=>a.nombre.Contains(filtro)).ToListAsync(); 
            //Modificar para que devuelva solo los autores activos en todos los get 
        }

        [HttpGet("deleteds")] //Agregar en nuestro proyecto y en los demas controladore
        public async Task<ActionResult<IEnumerable<Autor>>> GetDeletedsAutores([FromQuery] string filtro = "")
        {
            return await _context.Autores.AsNoTracking().IgnoreQueryFilters().Where(a => a.IsDeleted).ToListAsync();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(a => a.id.Equals(id));


            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.id)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.id }, autor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            autor.IsDeleted = true; // Marcar como eliminado en lugar de eliminar físicamente
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        [HttpPut("restore/{id}")] // Agregar en nuestro proyecto

        public async Task<IActionResult> RestoreAutor(int id)
        {
            var autor = await _context.Autores.IgnoreQueryFilters().FirstOrDefaultAsync(a=>a.id.Equals(id));
            if (autor == null)
            {
                return NotFound();
            }
            autor.IsDeleted = false; // Restaurar el autor
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.id == id);
        }
    }
}
