using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Register
{
    public class CompanyModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        public Company InputCompany { get; set; }
        [BindProperty]
        public IFormFile CompanyLogo { get; set; }
        public IHostingEnvironment _environment { get; set; }
        public ProjectTamaraContext _context { get; set; }
        public UserManager<BaseUser> _userManager { get; set; }
        public SignInManager<BaseUser> _signInManager { get; set; }

        public CompanyModel(IHostingEnvironment environment, ProjectTamaraContext context, UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(CompanyLogo == null)
            {
                InputCompany.CompanyLogo = "";
            }
            else
            {
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(CompanyLogo.FileName);
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot", "icons", filename);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await CompanyLogo.CopyToAsync(fileStream);
                }
                InputCompany.CompanyLogo = filename;
            }
            _context.Company.Add(InputCompany);
            BaseUser user = new BaseUser { UserName = InputCompany.CompanyId, Email = InputCompany.CompanyId, Role = "Company" };
            var result = await _userManager.CreateAsync(user, Password);

            await _context.SaveChangesAsync();

            BaseUser currentUser = await _userManager.FindByNameAsync(InputCompany.CompanyId);

            await _signInManager.SignInAsync(currentUser, isPersistent: false);
            return RedirectToPage("/Index");
        }
    }
}