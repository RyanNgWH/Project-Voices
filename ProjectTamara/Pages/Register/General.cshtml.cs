using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Register
{
    public class GeneralModel : PageModel
    {
        [BindProperty]
        [Required]
        public GeneralUser InputGeneralUser { get; set; }
        public ProjectTamaraContext _context { get; set; }
        public UserManager<BaseUser> _userManager { get; set; }
        public SignInManager<BaseUser> _signInManager { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }

        public GeneralModel(ProjectTamaraContext context, UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
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
            _context.GeneralUser.Add(InputGeneralUser);
            BaseUser user = new BaseUser { UserName = InputGeneralUser.GeneralUserId, Email = InputGeneralUser.GeneralUserId, Role = "General User"};
            var result = await _userManager.CreateAsync(user, Password);

            await _context.SaveChangesAsync();

            BaseUser currentUser = await _userManager.FindByNameAsync(InputGeneralUser.GeneralUserId);

            await _signInManager.SignInAsync(currentUser, isPersistent: false);

            return RedirectToPage("/Index");
        }
    }
}