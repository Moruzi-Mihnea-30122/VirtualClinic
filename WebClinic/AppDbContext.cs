using Microsoft.EntityFrameworkCore;
using WebClinic.Models;

namespace WebClinic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options ) { }
        public DbSet<Pacients> Pacients { get; set; }
        public DbSet<Medics> Medics { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
    }
}
