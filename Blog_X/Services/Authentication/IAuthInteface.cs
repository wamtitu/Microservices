using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_X.Models;
using Blog_X.Models.Auth;

namespace Blog_X.Services.Authentication
{
    public interface IAuthInteface
    {
        Task<LoginResponseDto> Login(LoginDto newLogin);
        Task<ResponseDto> Register(RegisterDto newRegister);
    }
}