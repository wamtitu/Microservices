using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auth_Blogger.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } =string.Empty;
    }
}