using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rabota1.Data;
using Rabota1.Models;

namespace Rabota1.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? CarTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SelectedCarType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> typeQuery = from m in _context.Car
                                            orderby m.CarType
                                            select m.CarType;

            var cars = await _context.Car.ToListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.Brand.Contains(SearchString, StringComparison.OrdinalIgnoreCase) || 
                                        s.Model.Contains(SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(SelectedCarType))
            {
                cars = cars.Where(x => x.CarType == SelectedCarType).ToList();
            }

            CarTypes = new SelectList(await typeQuery.Distinct().ToListAsync());
            Car = cars;
        }
    }
}
