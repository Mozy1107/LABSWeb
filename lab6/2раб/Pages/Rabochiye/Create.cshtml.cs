using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages.Rabochiye
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
        public Rabochiy Rabochiy { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Rabochiy.EmployeeType = "Рабочий";
            _context.Rabochiy.Add(Rabochiy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
