using Microsoft.EntityFrameworkCore;
using WebClinic.Models;

namespace WebClinic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options ) { }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
