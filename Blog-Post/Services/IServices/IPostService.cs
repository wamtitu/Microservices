using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.Models;

namespace Blog_Post.Services.IServices
{
    public interface IPostService
    {
        Task<string> CreatePostAsync(Post newPost);
        Task<string> DeletePostAsync(Post newpost);
        Task<string> UpdatePostAsync(Post newPost);
        Task<List<Post>> GetPostsAsync();
        Task <Post> GetPostById(Guid Id);
    }
}