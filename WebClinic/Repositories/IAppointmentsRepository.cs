using WebClinic.Models;

namespace WebClinic.Repositories
{
    public interface IAppointmentsRepository
    {
        void Store(Appointment appointment);

        Task SaveChanges();

        IQueryable<Appointment> Query();

        void Delete(Appointment appointment);
    }
}
