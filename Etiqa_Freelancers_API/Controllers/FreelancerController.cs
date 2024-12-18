using Etiqa_Freelancers_API.Data;
using Etiqa_Freelancers_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Etiqa_Freelancers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FreelancerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFreelancer([FromBody] Freelancer freelancer)
        {
            _context.AddAsync(freelancer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFreelancerById), new { id = freelancer.Id }, freelancer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancerById(int id)
        {
            var freelancer = await _context.Freelancers
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
            .FirstOrDefaultAsync(f => f.Id == id);

            if (freelancer == null)
            {
                return NotFound();
            }

            return Ok(freelancer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancer(int id, [FromBody] Freelancer freelancer)
        {
            if (id != freelancer.Id)
            {
                return BadRequest();
            }
            _context.Entry(freelancer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }

            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchFreelancers(string query)
        {
            var results = await _context.Freelancers
                .Where(f => f.Username.Contains(query) || f.Email.Contains(query))
                .ToListAsync();
            return Ok(results);
        }

        [HttpPatch("{id}/archive")]
        public async Task<IActionResult> ArchiveFreelancer(int id, [FromQuery] bool archive)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            freelancer.Archived = archive;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }


}
