using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.Models.Dtos;

namespace Auth_Blogger.Services.IServices
{
    public interface IUserServices
    {
        Task<string> RegisterUser(RegistrationDto newUser);
        Task<LoginResponseDto> Login(LoginRequestDto newLogin);
    }
}