using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebClinic;
using WebClinic.Models;

namespace WebClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Medics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medics>>> GetMedics()
        {
            return await _context.Medics.ToListAsync();
        }

        // GET: api/Medics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medics>> GetMedics(int id)
        {
            var medics = await _context.Medics.FindAsync(id);

            if (medics == null)
            {
                return NotFound();
            }

            return medics;
        }

        // PUT: api/Medics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedics(int id, Medics medics)
        {
            if (id != medics.Id)
            {
                return BadRequest();
            }

            _context.Entry(medics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicsExists(id))
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

        // POST: api/Medics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medics>> PostMedics(Medics medics)
        {
            _context.Medics.Add(medics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedics", new { id = medics.Id }, medics);
        }

        // DELETE: api/Medics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedics(int id)
        {
            var medics = await _context.Medics.FindAsync(id);
            if (medics == null)
            {
                return NotFound();
            }

            _context.Medics.Remove(medics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicsExists(int id)
        {
            return _context.Medics.Any(e => e.Id == id);
        }
    }
}
