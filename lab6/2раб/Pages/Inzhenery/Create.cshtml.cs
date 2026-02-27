using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Inzhenery
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Inzhener Inzhener { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Inzhener.EmployeeType = "Инженер";
            _context.Inzhener.Add(Inzhener);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
