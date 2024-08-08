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
    public class ReferencePersonalsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ReferencePersonalsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/ReferencePersonals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferencePersonal>>> GetReferencePersonals()
        {
            return await _context.ReferencePersonals.ToListAsync();
        }

        // GET: api/ReferencePersonals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferencePersonal>> GetReferencePersonal(int id)
        {
            var referencePersonal = await _context.ReferencePersonals.FindAsync(id);

            if (referencePersonal == null)
            {
                return NotFound();
            }

            return referencePersonal;
        }

        // PUT: api/ReferencePersonals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferencePersonal(int id, ReferencePersonal referencePersonal)
        {
            if (id != referencePersonal.Id)
            {
                return BadRequest();
            }

            _context.Entry(referencePersonal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferencePersonalExists(id))
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

        // POST: api/ReferencePersonals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferencePersonal>> PostReferencePersonal(ReferencePersonal referencePersonal)
        {
            _context.ReferencePersonals.Add(referencePersonal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferencePersonal", new { id = referencePersonal.Id }, referencePersonal);
        }

        // DELETE: api/ReferencePersonals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencePersonal(int id)
        {
            var referencePersonal = await _context.ReferencePersonals.FindAsync(id);
            if (referencePersonal == null)
            {
                return NotFound();
            }

            _context.ReferencePersonals.Remove(referencePersonal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferencePersonalExists(int id)
        {
            return _context.ReferencePersonals.Any(e => e.Id == id);
        }
    }
}
