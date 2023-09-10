using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Post.Models;
using Blog_Post.Models.Dtos;

namespace Blog_Post.Profiles
{
    public class MyProfiles :Profile
    {
        public MyProfiles()
        {
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}