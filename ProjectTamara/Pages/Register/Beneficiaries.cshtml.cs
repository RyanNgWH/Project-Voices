using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Register
{
    public class BeneficiariesModel : PageModel
    {
        [Required]
        [BindProperty]
        public Beneficiary InputBeneficiary { get; set; }
        public ProjectTamaraContext _context { get; set; }
        public UserManager<BaseUser> _userManager { get; set; }
        public SignInManager<BaseUser> _signInManager { get; set; }
        [BindProperty]
        [Required]
        public string icon { get; set; }

        public BeneficiariesModel(ProjectTamaraContext context, UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager)
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
            BeneficiaryCodes checkBc = _context.BeneficiaryCodes.FirstOrDefault(cbc => (cbc.BeneficiaryCodesId == InputBeneficiary.BeneficiaryId));
            if(checkBc == null)
            {
                ModelState.AddModelError("FailedbcCheck", "Invalid Beneficiary Code!");
                return Page();
            }
            _context.Add(InputBeneficiary);

            BaseUser user = new BaseUser { UserName = InputBeneficiary.BeneficiaryId, Email = InputBeneficiary.EmailAddress, Role = "Beneficiary", Icon = icon };
            var result = await _userManager.CreateAsync(user, "Password0)");

            await _context.SaveChangesAsync();

            BaseUser currentUser = await _userManager.FindByNameAsync(InputBeneficiary.BeneficiaryId);

            await _signInManager.SignInAsync(currentUser, isPersistent: false);

            return RedirectToPage("/Index");
        }
    }
}