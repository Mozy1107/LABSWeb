using Microsoft.EntityFrameworkCore;
using Rabota2.Models;

namespace Rabota2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rabochiy> Rabochiy { get; set; } = default!;
        public DbSet<Inzhener> Inzhener { get; set; } = default!;
        public DbSet<Administraciya> Administraciya { get; set; } = default!;
    }
}
