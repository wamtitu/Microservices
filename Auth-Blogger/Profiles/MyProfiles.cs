using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.Models;
using Auth_Blogger.Models.Dtos;
using AutoMapper;

namespace Auth_Blogger.Profiles
{
    public class MyProfiles : Profile
    {
        public MyProfiles()
        {
            CreateMap<RegistrationDto, AppUser>().ForMember(dest => dest.UserName, u=>u.MapFrom(reg=>reg.Email));

            CreateMap<AppUser, UserDto>().ReverseMap();

        }
    }
}