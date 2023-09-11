using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Post.DbConnection;
using Blog_Post.Models;
using Blog_Post.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Blog_Post.Services
{
    public class PostService : IPostService
    {
        private readonly AppConnection _context;
        private readonly IMapper _mapper;
        private readonly ICommentsService _commentService;

        public PostService(AppConnection context, IMapper mapper, ICommentsService commentService)
        {
            _context = context;
            _mapper = mapper;
            _commentService = commentService;
        }
        public async Task<string> CreatePostAsync(Post newPost)
        {
            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return "Blog posted succesfully";
            
        }

        public async Task<string> DeletePostAsync(Post newpost)
        {
            _context.Posts.Remove(newpost);
            await _context.SaveChangesAsync();
            return "Post deleted successfully";
            
        }

        public async Task<Post> GetPostById(Guid Id)
        {
            var post= await _context.Posts.FirstOrDefaultAsync(u=>u.PostId == Id);
            if(post !=null){
                post.Comments = await _commentService.GetCommentsAsync(Id);
                return post;
            }
            return new Post();
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _context.Posts.Include(p => p.Comments).ToListAsync();
        }

        public async Task<List<Post>> GetUSersPosts(Guid id)
        {
            return await _context.Posts.Where(u=>u.UserId == id).ToListAsync();
        }

        public async Task<string> UpdatePostAsync(Post newPost)
        {
            _context.Posts.Update(newPost);
            await _context.SaveChangesAsync();
            return "post updated successfully";
        }
    }
}