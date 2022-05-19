using Microsoft.EntityFrameworkCore;
using TODO_App.Data.Models;

namespace TODO_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Zadatak> Zadaci { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
    }
}
