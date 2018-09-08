using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly ProjectTamara.Models.ProjectTamaraContext _context;

        public CreateModel(ProjectTamara.Models.ProjectTamaraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}