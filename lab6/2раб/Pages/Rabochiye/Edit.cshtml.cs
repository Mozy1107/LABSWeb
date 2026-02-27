using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Rabochiye
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            Rabochiy = rabochiy;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Rabochiy.EmployeeType = "Рабочий";
            _context.Rabochiy.Update(Rabochiy);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RabochiyExists(Rabochiy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RabochiyExists(int id)
        {
            return _context.Rabochiy.Any(e => e.Id == id);
        }
    }
}
