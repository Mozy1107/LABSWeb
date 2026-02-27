using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Administraciya
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Administraciya Administraciya { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administraciya = await _context.Administraciya.FirstOrDefaultAsync(m => m.Id == id);
            if (administraciya == null)
            {
                return NotFound();
            }
            else
            {
                Administraciya = administraciya;
            }
            return Page();
        }
    }
}
