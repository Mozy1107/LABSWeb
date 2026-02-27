using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rabota2.Data;
using Rabota2.Models;

namespace Rabota2.Pages
{
    public class ZaprosyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ZaprosyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Rabochiy> RabochiyeByCeh { get; set; } = new List<Rabochiy>();
        public IList<Inzhener> InzheneryByPodrazdelenie { get; set; } = new List<Inzhener>();
        
        public string? SelectedCeh { get; set; }
        public string? SelectedPodrazdelenie { get; set; }
        public int InzheneryCount { get; set; }
        
        public int TotalRabochiye { get; set; }
        public int TotalInzhenery { get; set; }
        public int TotalAdministraciya { get; set; }
        public int TotalEmployees { get; set; }

        public async Task OnGetAsync(string? ceh, string? podrazdelenie)
        {
            TotalRabochiye = await _context.Rabochiy.CountAsync();
            TotalInzhenery = await _context.Inzhener.CountAsync();
            TotalAdministraciya = await _context.Administraciya.CountAsync();
            TotalEmployees = TotalRabochiye + TotalInzhenery + TotalAdministraciya;

            if (!string.IsNullOrEmpty(ceh))
            {
                SelectedCeh = ceh;
                RabochiyeByCeh = await _context.Rabochiy
                    .Where(r => r.Ceh == ceh)
                    .OrderBy(r => r.Name)
                    .ToListAsync();
            }

            if (!string.IsNullOrEmpty(podrazdelenie))
            {
                SelectedPodrazdelenie = podrazdelenie;
                InzheneryByPodrazdelenie = await _context.Inzhener
                    .Where(i => i.Podrazdelenie == podrazdelenie)
                    .OrderBy(i => i.Name)
                    .ToListAsync();
                InzheneryCount = InzheneryByPodrazdelenie.Count;
            }
        }
    }
}
