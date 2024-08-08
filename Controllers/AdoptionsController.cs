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
    public class AdoptionsController : ControllerBase
    {
        const string adopted = "ADOPTED";

        private readonly SqlDbContext _context;

        public AdoptionsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Adoptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adoption>>> GetAdoption()
        {
            return await _context.Adoption.ToListAsync();
        }

        // GET: api/Adoptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adoption>> GetAdoption(int id)
        {
            var adoption = await _context.Adoption.FindAsync(id);

            if (adoption == null)
            {
                return NotFound();
            }

            return adoption;
        }

        // PUT: api/Adoptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoption(int id, Adoption adoption)
        {
            if (id != adoption.Id)
            {
                return BadRequest();
            }

            _context.Entry(adoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionExists(id))
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

        // POST: api/Adoptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adoption>> PostAdoption(Adoption adoption)
        {
            adoption.Pet.Available = false;

            _context.Adoption.Add(adoption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdoption", new { id = adoption.Id }, adoption);
        }
        [HttpPost("adopted/{id}")]
        public async Task<ActionResult<Adoption>> Adopted(int id)
        {
            var req = await _context.Adoption.FindAsync(id);

            if (req == null)
            {
                return NotFound();
            }

            req.AdoptionCompletedDate = DateTime.Now;
            req.Pet.Available = false;
            req.PaperworkDone = true;
            req.PaymentDone = true;
            req.AdoptionRequest.Status = adopted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return req;
        }

        // DELETE: api/Adoptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoption(int id)
        {
            var adoption = await _context.Adoption.FindAsync(id);
            if (adoption == null)
            {
                return NotFound();
            }

            _context.Adoption.Remove(adoption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdoptionExists(int id)
        {
            return _context.Adoption.Any(e => e.Id == id);
        }
    }
}
