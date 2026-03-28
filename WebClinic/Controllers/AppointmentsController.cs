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
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments([FromQuery] int? pacientId)
        {
            var query = _appointmentsRepository.Query();
            if (pacientId != null)
            {
                query = query.Where(p => p.PacientId == pacientId);
            }
            return await query.ToListAsync();
        }


        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointments(int id, Appointment appointments)
        {
            if (id != appointments.Id)
            {
                return BadRequest();
            }

            _appointmentsRepository.Store(appointments);

            await _appointmentsRepository.SaveChanges();

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointments(Appointment appointments)
        {
            
            var appointmentIntervalLow = appointments.Date.AddMinutes(-30);
            var appointmentIntervalHigh = appointments.Date.AddMinutes(30);
            var doctorIsBusy = await _appointmentsRepository.Query().AnyAsync(p => 
            p.Date > appointmentIntervalLow && 
            p.Date < appointmentIntervalHigh && 
            p.MedicId == appointments.MedicId);

            if (doctorIsBusy)
            {
                return BadRequest("Medic is busy");
            }

            var pacientIsBusy = await _appointmentsRepository.Query().AnyAsync(p => 
            p.PacientId == appointments.PacientId && 
            p.Date > appointmentIntervalLow && 
            p.Date < appointmentIntervalHigh);

            if (pacientIsBusy)
            {
                return BadRequest("Pacient is busy");
            }

            _appointmentsRepository.Store(appointments);
            await _appointmentsRepository.SaveChanges();

            return CreatedAtAction("GetAppointments", new { id = appointments.Id }, appointments);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointments(int id)
        {
            var appointments = await _appointmentsRepository.Query().FirstOrDefaultAsync(a => a.Id == id);
            if (appointments == null)
            {
                return NotFound();
            }

            _appointmentsRepository.Delete(appointments);
            await _appointmentsRepository.SaveChanges();

            return NoContent();
        }

        private bool AppointmentsExists(int id)
        {
            return _appointmentsRepository.Query().Any(e => e.Id == id);
        }
    }
}
