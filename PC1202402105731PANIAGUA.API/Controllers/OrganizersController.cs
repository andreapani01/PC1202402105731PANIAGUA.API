using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC1202402105731PANIAGUA.DOMAIN.Core.Entities;
using PC1202402105731PANIAGUA.DOMAIN.Infraestructure.Data;

namespace PC1202402105731PANIAGUA.API.Controllers
{
    public class OrganizersController : ControllerBase
    {
        private readonly EventManagementDbContext _context;

        public OrganizersController(EventManagementDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizers>>> GetOrganizers()
        {
            return await _context.Organizers.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizers>> GetOrganizers(int id)
        {
            var organizers = await _context.Organizers.FindAsync(id);

            if (organizers == null)
            {
                return NotFound();
            }

            return organizers;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizers(int id, Organizers organizers)
        {
            if (id != organizers.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizersExists(id))
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

        // POST

        [HttpPost]
        public async Task<ActionResult<Organizers>> PostOrganizers(Organizers organizers)
        {
            _context.Organizers.Add(organizers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizers", new { id = organizers.Id }, organizers);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizers(int id)
        {
            var organizers = await _context.Organizers.FindAsync(id);
            if (organizers == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizersExists(int id)
        {
            return _context.Organizers.Any(e => e.Id == id);
        }
    }
}
