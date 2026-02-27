using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Rabochiye
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rabochiy = await _context.Rabochiy.FindAsync(id);
            if (rabochiy != null)
            {
                Rabochiy = rabochiy;
                _context.Rabochiy.Remove(Rabochiy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
