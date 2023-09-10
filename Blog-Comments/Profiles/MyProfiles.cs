using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Comments.Models;
using Blog_Comments.Models.Dtos;

namespace Blog_Comments.Profiles
{
    public class MyProfiles:Profile
    {
        public MyProfiles()
        {
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}