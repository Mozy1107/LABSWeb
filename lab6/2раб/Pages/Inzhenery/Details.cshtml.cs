using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Inzhenery
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Inzhener Inzhener { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inzhener = await _context.Inzhener.FirstOrDefaultAsync(m => m.Id == id);
            if (inzhener == null)
            {
                return NotFound();
            }
            else
            {
                Inzhener = inzhener;
            }
            return Page();
        }
    }
}
