using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly ProjectTamara.Models.ProjectTamaraContext _context;

        public IndexModel(ProjectTamara.Models.ProjectTamaraContext context)
        {
            _context = context;
        }

        public List<Service> Service { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Service = await _context.Service.ToListAsync();
            return Page();
        }
    }
}
