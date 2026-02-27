using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Rabochiye
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Rabochiy Rabochiy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabochiy = await _context.Rabochiy.FirstOrDefaultAsync(m => m.Id == id);
            if (rabochiy == null)
            {
                return NotFound();
            }
            else
            {
                Rabochiy = rabochiy;
            }
            return Page();
        }
    }
}
