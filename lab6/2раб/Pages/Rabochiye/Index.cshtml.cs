using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Rabochiye
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Rabochiy> Rabochiy { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Rabochiy = await _context.Rabochiy.ToListAsync();
        }
    }
}
