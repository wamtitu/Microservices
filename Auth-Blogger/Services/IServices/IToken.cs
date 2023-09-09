using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.Models;

namespace Auth_Blogger.Services.IServices
{
    public interface IToken
    {
        string GenerateToken(AppUser user);
    }
}