using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTamara.Data
{
    public class BaseUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
