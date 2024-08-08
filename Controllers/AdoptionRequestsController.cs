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
    public class AdoptionRequestsController : ControllerBase
    {
        const string rejected = "REJECTED";
        const string approved = "APPROVED";
        const string review = "REVIEW";
        const string onhold = "ONHOLD";
        const string adopted = "ADOPTED";

        private readonly SqlDbContext _context;

        public AdoptionRequestsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/AdoptionRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdoptionRequest>>> GetAdoptionRequests()
        {
            return await _context.AdoptionRequests.ToListAsync();
        }

        // GET: api/AdoptionRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdoptionRequest>> GetAdoptionRequest(int id)
        {
            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);

            if (adoptionRequest == null)
            {
                return NotFound();
            }

            return adoptionRequest;
        }

        // PUT: api/AdoptionRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoptionRequest(int id, AdoptionRequest adoptionRequest)
        {
            if (id != adoptionRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(adoptionRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionRequestExists(id))
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

        // POST: api/AdoptionRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdoptionRequest>> PostAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            adoptionRequest.Status = review;

            _context.AdoptionRequests.Add(adoptionRequest);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdoptionRequest", new { id = adoptionRequest.Id }, adoptionRequest);
        }

        [HttpPost("reject/{AdoptRequestId}")]
        public async Task<ActionResult<AdoptionRequest>> Reject(int id, [FromBody] string rejectionReason)
        {
            var req = await _context.AdoptionRequests.FindAsync(id);
            if(req== null)
            {
                return NotFound();
            }

            req.RejectionReason = rejectionReason;
            req.Status = rejected;

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

        [HttpPost("approve/{AdoptRequestId}")]
        public async Task<ActionResult<AdoptionRequest>> Approve(int id)
        {
            var req = await _context.AdoptionRequests.FindAsync(id);

            if(req== null)
            {
                return NotFound();
            }

            req.Status = approved;

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
        [HttpPost("onhold/{AdoptRequestId}")]
        public async Task<ActionResult<AdoptionRequest>> Onhold(int id)
        {
            var req = await _context.AdoptionRequests.FindAsync(id);

            if (req == null)
            {
                return NotFound();
            }

            req.Status = onhold;

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
        

        // DELETE: api/AdoptionRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoptionRequest(int id)
        {
            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }

            _context.AdoptionRequests.Remove(adoptionRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdoptionRequestExists(int id)
        {
            return _context.AdoptionRequests.Any(e => e.Id == id);
        }
    }
}
