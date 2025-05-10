using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomBaseAPI.Data;
using HomBaseAPI.Model;

namespace HomBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/properties
        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] Property property)
        {
            property.DateListed = DateTime.UtcNow;
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        // GET: api/properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/properties/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _context.Properties
                                         //.Include(p => p.Interests)  
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
                return NotFound();

            return property;
        }

        // PUT: api/properties/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _context.Entry(property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // DELETE: api/properties/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
