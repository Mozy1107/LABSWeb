using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;

namespace Rabota2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int RabochiyeCount { get; set; }
        public int InzheneryCount { get; set; }
        public int AdministraciyaCount { get; set; }

        public async Task OnGetAsync()
        {
            RabochiyeCount = await _context.Rabochiy.CountAsync();
            InzheneryCount = await _context.Inzhener.CountAsync();
            AdministraciyaCount = await _context.Administraciya.CountAsync();
        }
    }
}
