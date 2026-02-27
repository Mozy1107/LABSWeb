using Microsoft.EntityFrameworkCore;
using Rabota1.Models; 

namespace Rabota1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } = default!;
        
        // Если ты делаешь Вариант №3 (Кадры), добавь эти строки:
        public DbSet<Worker> Workers { get; set; } = default!;
        public DbSet<Engineer> Engineers { get; set; } = default!;
        public DbSet<Administration> Administrations { get; set; } = default!;
    }
}