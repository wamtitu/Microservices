using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Blogger.Models.Dtos
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; } = default!;

        public string Token { get; set; } = string.Empty;
    }
}