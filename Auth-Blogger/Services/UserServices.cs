using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.DbConnections;
using Auth_Blogger.Models;
using Auth_Blogger.Models.Dtos;
using Auth_Blogger.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth_Blogger.Services
{
    public class UserServices : IUserServices
    {
        private readonly MyConnection _connection;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IToken _token;

        public UserServices(MyConnection connection,IToken token, UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _connection = connection;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _token = token;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto newLogin)
        {
           var user = await _connection.AppUsers.FirstOrDefaultAsync(u=>u.UserName.ToLower() == newLogin.Email.ToLower());
           var validPassword = await _userManager.CheckPasswordAsync(user, newLogin.Password);
           System.Console.WriteLine(user.Name);
           if(!validPassword || user == null){
           var notlogged= new LoginResponseDto();
           return notlogged;
           } 
           var token = _token.GenerateToken(user);
           var loggedInUser = new LoginResponseDto(){
            User = _mapper.Map<UserDto>(user),
            Token = token
           } ;
           return loggedInUser;
        }

        public async Task<string> RegisterUser(RegistrationDto newUser)
        {
            var user = _mapper.Map<AppUser>(newUser);
           try
           {
            var created = await _userManager.CreateAsync(user, newUser.Password);
            if (created.Succeeded){
                return "";
            }else{
                return created.Errors.FirstOrDefault().Description;
            }
           }
           catch (System.Exception ex)
           {
            
             return ex.Message;
           };
        }
    }
}