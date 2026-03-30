using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebClinic.Models;

namespace WebClinic.Repositories
{
    public class MedicsRepository(AppDbContext _context) : IMedicsRepository
    {
        public void DeleteMedic(Medic medic)
        {
            _context.Medics.Remove(medic);
        }

        public ValueTask<Medic?> GetMedicById(int id)
        {
            return _context.Medics.FindAsync(id);
        }

        public IQueryable<Medic> Query()
        {
            return _context.Medics;
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public void StoreMedic(Medic medic)
        {
            var medicExists = _context.Medics.Any(m => m.Id == medic.Id);
            if (medicExists)
            {
                _context.Entry(medic).State = EntityState.Modified;
                return;
            }
            _context.Medics.Add(medic);
        }
    }
}
