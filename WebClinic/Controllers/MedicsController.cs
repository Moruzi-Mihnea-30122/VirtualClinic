using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebClinic;
using WebClinic.Models;
using WebClinic.Repositories;

namespace WebClinic.Controllers
{
    [Route("api/medics")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly IMedicsRepository _medicsRepository;

        public MedicsController(AppDbContext context, IMedicsRepository medicsRepository)
        {
            _medicsRepository = medicsRepository;
        }

        // GET: api/Medics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> GetMedics()
        {
            return await _medicsRepository.Query().ToListAsync();
        }

        // GET: api/Medics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medic>> GetMedics(int id)
        {
            var medics = await _medicsRepository.GetMedicById(id);

            if (medics == null)
            {
                return NotFound();
            }

            return medics;
        }

        // PUT: api/Medics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedics(int id, Medic medics)
        {
            if (id != medics.Id)
            {
                return BadRequest();
            }

            _medicsRepository.StoreMedic(medics);

            await _medicsRepository.SaveChanges();

            return NoContent();
        }

        // POST: api/Medics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medic>> PostMedics(Medic medics)
        {
            _medicsRepository.StoreMedic(medics);
            await _medicsRepository.SaveChanges();

            return CreatedAtAction("GetMedics", new { id = medics.Id }, medics);
        }

        // DELETE: api/Medics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedics(int id)
        {
            var medics = await _medicsRepository.GetMedicById(id);
            if (medics == null)
            {
                return NotFound();
            }

            _medicsRepository.DeleteMedic(medics);
            await _medicsRepository.SaveChanges();

            return NoContent();
        }

        private bool MedicsExists(int id)
        {
            return _medicsRepository.Query().Any(e => e.Id == id);
        }
    }
}
