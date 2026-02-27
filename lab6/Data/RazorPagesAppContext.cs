using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Data
{
    public class RazorPagesAppContext : DbContext
    {
        public RazorPagesAppContext(DbContextOptions<RazorPagesAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
