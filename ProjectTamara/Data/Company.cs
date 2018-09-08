using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class Company
    {
        [Required]
        [Display(Name = "User Name")]
        public string CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
    }
}
