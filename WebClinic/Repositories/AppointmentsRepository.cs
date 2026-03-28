using Microsoft.EntityFrameworkCore;
using WebClinic.Models;

namespace WebClinic.Repositories
{
    public class AppointmentsRepository(AppDbContext _context): IAppointmentsRepository
    {
        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public IQueryable<Appointment> Query()
        {
            return _context.Appointments;
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void Store(Appointment appointment)
        {
            var appoimentExists = _context.Appointments.Any(a => a.Id == appointment.Id);
            if(appoimentExists)
            {
                _context.Entry(appointment).State = EntityState.Modified;
                return;
            }
            _context.Appointments.Add(appointment);
        }

    }
}
