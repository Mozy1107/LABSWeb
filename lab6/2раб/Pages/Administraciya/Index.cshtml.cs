using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Administraciya
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Administraciya> Administraciya { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Administraciya = await _context.Administraciya.ToListAsync();
        }
    }
}
