using WebClinic.Models;

namespace WebClinic.Repositories
{
    public interface IMedicsRepository
    {
        void StoreMedic(Medic medic);
        Task SaveChanges();
        void DeleteMedic(Medic medic);
        IQueryable<Medic> Query();
        ValueTask<Medic?> GetMedicById(int id);
    }
}
