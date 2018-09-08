using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProjectTamara.Models.ProjectTamaraContext _context;
        public IList<Service> Service { get; set; }

        public IndexModel(ProjectTamara.Models.ProjectTamaraContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task OnGetAsync(string listingCategory, string searchString)
        {
            var services = from s in _context.Service
                           select s;
            services = services.OrderByDescending(t => t.Votes);

            Service = await services.ToListAsync();
        }
    }
}
