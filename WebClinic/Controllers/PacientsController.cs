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
    public class PacientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacients>>> GetPacients()
        {
            return await _context.Pacients.ToListAsync();
        }

        // GET: api/Pacients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacients>> GetPacients(int id)
        {
            var pacients = await _context.Pacients.FindAsync(id);

            if (pacients == null)
            {
                return NotFound();
            }

            return pacients;
        }

        // PUT: api/Pacients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacients(int id, Pacients pacients)
        {
            if (id != pacients.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientsExists(id))
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

        // POST: api/Pacients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacients>> PostPacients(Pacients pacients)
        {
            bool pacientAlreadyExists = await _context.Pacients.AnyAsync(p =>
            p.Name == pacients.Name ||
            (p.EmailAddress == pacients.EmailAddress &&
            p.TelNumber == pacients.TelNumber));

            if (pacientAlreadyExists)
            {
                return BadRequest("Pacient already exists");
            }

            _context.Pacients.Add(pacients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacients", new { id = pacients.Id }, pacients);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login( LoginDto loginData)
        {
            var user = await _context.Pacients.FirstOrDefaultAsync(p => p.EmailAddress == loginData.Email && p.Password == loginData.Password);

            if (user == null) { return NotFound(); }

            return Ok(new
            {
                id = user.Id,
                name = user.Name,
                role = user.Role
            });
        }

        // DELETE: api/Pacients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacients(int id)
        {
            var pacients = await _context.Pacients.FindAsync(id);
            if (pacients == null)
            {
                return NotFound();
            }

            _context.Pacients.Remove(pacients);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientsExists(int id)
        {
            return _context.Pacients.Any(e => e.Id == id);
        }
    }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
