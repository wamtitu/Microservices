using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_X.Models;
using Blog_X.Models.Post;

namespace Blog_X.Services.Posts
{
    public interface IPostInterface
    {
        Task<List<PostDto>> GetPostsAsync();
        Task<PostDto> GetPostByIdAsync(Guid Id);
        Task<List<PostDto>> GetPostByUserIdAsync(Guid Id);
        Task<ResponseDto> DeletePostAsync(Guid Id);
        Task<ResponseDto> UpdatePostAsync(Guid id, PostDto UpdatedPost);
        Task<string> AddPostAsync(PostDto newPost);
    }
}