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
    public class AppointmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointments(int id)
        {
            var appointments = await _context.Appointments.Where(p => p.pacientId == id).ToListAsync();

            if (appointments == null)
            {
                return NotFound();
            }

            return appointments;
        }
        [HttpGet("pacients/{id}")]
        public async Task<ActionResult<IEnumerable<Appointments>>> GetProgramariPacient(int id)
        {
            return await _context.Appointments
                .Where(p => p.pacientId == id)
                .ToListAsync();
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointments(int id, Appointments appointments)
        {
            if (id != appointments.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentsExists(id))
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

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointments>> PostAppointments(Appointments appointments)
        {
            
            var appointmentIntervalLow = appointments.date.AddMinutes(-30);
            var appointmentIntervalHigh = appointments.date.AddMinutes(30);
            bool doctorIsBusy = await _context.Appointments.AnyAsync(p => 
            p.date > appointmentIntervalLow && 
            p.date < appointmentIntervalHigh && 
            p.medicId == appointments.medicId);

            if (doctorIsBusy)
            {
                return BadRequest("Medic is busy");
            }

            bool pacientIsBusy = await _context.Appointments.AnyAsync(p => 
            p.pacientId == appointments.pacientId && 
            p.date > appointmentIntervalLow && 
            p.date < appointmentIntervalHigh);

            if (pacientIsBusy)
            {
                return BadRequest("Pacient is busy");
            }

            _context.Appointments.Add(appointments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointments", new { id = appointments.Id }, appointments);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointments(int id)
        {
            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentsExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
