using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectTamara.Models.ProjectTamaraContext _context;

        public UserManager<BaseUser> _userManager { get; set; }

        public DetailsModel(ProjectTamara.Models.ProjectTamaraContext context, UserManager<BaseUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Service Service { get; set; }
        public Beneficiary CreatedBy { get; set; }
        public bool hasVoted { get; set; }
        [BindProperty]
        public string Comment { get; set; }

        public List<Comment> Comments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service = await _context.Service.FirstOrDefaultAsync(m => (m.ServiceId == id));
            if (Service == null)
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            CreatedBy = await _context.Beneficiary.FirstOrDefaultAsync(q => (q.BeneficiaryId == Service.CreatedBy.UserName));
            VoteLog vl = await _context.VoteLog.FirstOrDefaultAsync(q => (q.CorrService.ServiceId == Service.ServiceId && currentUser.UserName == CreatedBy.BeneficiaryId));
            hasVoted = (vl == null) ? false : true;
            Comments = await _context.Comment.Where(c => c.CommentedOn.ServiceId == Service.ServiceId).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostVoteAsync(int ServiceId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            Service service = await _context.Service.FirstOrDefaultAsync(q => (q.ServiceId == ServiceId));
            Beneficiary cbc = await _context.Beneficiary.FirstOrDefaultAsync(q => (q.BeneficiaryId == currentUser.UserName));
            VoteLog vl_new = new VoteLog() { VoteLogId = Guid.NewGuid().ToString(), CorrService = service, Beneficiary = cbc };
            _context.VoteLog.Add(vl_new);
            service.Votes++;
            await _context.SaveChangesAsync();
            return RedirectToPage(new { id = ServiceId });
        }

        public async Task<IActionResult> OnPostAsync(int ServiceId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            Service service = await _context.Service.FirstOrDefaultAsync(q => (q.ServiceId == ServiceId));
            Beneficiary cbc = await _context.Beneficiary.FirstOrDefaultAsync(q => (q.BeneficiaryId == currentUser.UserName));
            Comment newComment = new Comment() { CommentId = Guid.NewGuid().ToString(), CommentContent = Comment, CommentedOn = service, Commenter = cbc, DateCommented = DateTime.Now };
            _context.Comment.Add(newComment);
            await _context.SaveChangesAsync();
            return RedirectToPage(new { id = ServiceId });
        }
    }
}
