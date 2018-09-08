using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public IFormFile ServiceImage { get; set; }
        public IHostingEnvironment _environment { get; set; }

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

            //Upload Photo
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(ServiceImage.FileName);
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "",  filename);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await ServiceImage.CopyToAsync(fileStream);
            }
            Service.Photo = filename;

            //Default values
            Service.DateCreated = DateTime.Now;
            Service.Status = "Pending";
            Service.Votes = 0;

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}