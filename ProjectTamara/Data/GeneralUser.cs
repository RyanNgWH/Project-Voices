using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class GeneralUser
    {
        [Display(Name = "User Name")]
        public string GeneralUserId { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Income { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
