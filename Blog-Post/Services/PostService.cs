using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.Models;
using Blog_Post.Services.IServices;

namespace Blog_Post.Services
{
    public class PostService : IPostService
    {
        public Task<string> CreatePostAsync(Post newPost)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeletePostAsync(Post newpost)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePostAsync(Post newPost)
        {
            throw new NotImplementedException();
        }
    }
}