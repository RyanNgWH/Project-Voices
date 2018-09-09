using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public List<Service> Service { get; set; }
        public UserManager<BaseUser> _userManager { get; set; }

        public IndexModel(ProjectTamara.Models.ProjectTamaraContext context, UserManager<BaseUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                    Service = await _context.Service.Where(p => (p.Status == "Confirmed")).ToListAsync();
            }
            return Page();
        }
    }
}
