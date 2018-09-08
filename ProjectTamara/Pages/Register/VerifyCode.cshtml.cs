using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProjectTamara.Data;
using ProjectTamara.Models;

namespace ProjectTamara.Pages.Register
{
    public class VerifyCodeModel : PageModel
    {
        public BeneficiaryCodes bc { get; set; }
        public ProjectTamaraContext _context { get; set; }

        public VerifyCodeModel(ProjectTamaraContext context) {

            _context = context;
        }
        public JsonResult OnGetAsync(string code)
        {
            var nullResult = new JsonResult(JsonConvert.SerializeObject(null));

            if (code == null)
            {
                return nullResult;
            }
            bc = _context.BeneficiaryCodes.FirstOrDefault(qbc => (qbc.BeneficiaryCodesId == code));
            if(bc == null)
            {
                return nullResult;
            }
            var converted = JsonConvert.SerializeObject(bc);
            return new JsonResult(converted);
        }
    }
}