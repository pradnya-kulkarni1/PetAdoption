using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;

namespace PetAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ReferenceBackgroundsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ReferenceBackgroundsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/ReferenceBackgrounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferenceBackground>>> GetReferenceBackgrounds()
        {
            return await _context.ReferenceBackgrounds.ToListAsync();
        }

        // GET: api/ReferenceBackgrounds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferenceBackground>> GetReferenceBackground(int id)
        {
            var referenceBackground = await _context.ReferenceBackgrounds.FindAsync(id);

            if (referenceBackground == null)
            {
                return NotFound();
            }

            return referenceBackground;
        }

        // PUT: api/ReferenceBackgrounds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferenceBackground(int id, ReferenceBackground referenceBackground)
        {
            if (id != referenceBackground.Id)
            {
                return BadRequest();
            }

            _context.Entry(referenceBackground).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenceBackgroundExists(id))
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

        // POST: api/ReferenceBackgrounds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferenceBackground>> PostReferenceBackground(ReferenceBackground referenceBackground)
        {
            _context.ReferenceBackgrounds.Add(referenceBackground);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferenceBackground", new { id = referenceBackground.Id }, referenceBackground);
        }

        // DELETE: api/ReferenceBackgrounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferenceBackground(int id)
        {
            var referenceBackground = await _context.ReferenceBackgrounds.FindAsync(id);
            if (referenceBackground == null)
            {
                return NotFound();
            }

            _context.ReferenceBackgrounds.Remove(referenceBackground);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenceBackgroundExists(int id)
        {
            return _context.ReferenceBackgrounds.Any(e => e.Id == id);
        }
    }
}
