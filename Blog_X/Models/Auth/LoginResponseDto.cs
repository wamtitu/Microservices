using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_X.Models.Auth
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; } = default!;

        public string Token { get; set; } = string.Empty;
    }
}