using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Administraciya
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            Administraciya = administraciya;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Administraciya.EmployeeType = "Администрация";
            _context.Administraciya.Update(Administraciya);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministraciyaExists(Administraciya.Id))
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

        private bool AdministraciyaExists(int id)
        {
            return _context.Administraciya.Any(e => e.Id == id);
        }
    }
}
