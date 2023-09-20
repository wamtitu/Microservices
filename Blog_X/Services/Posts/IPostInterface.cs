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
        Task<ResponseDto> GetPostByIdAsync(Guid Id);
        Task<ResponseDto> DeletePostAsync(PostDto deletePost);
        Task<ResponseDto> UpdatePostAsync(PostDto UpdatedPost);
        Task<ResponseDto> AddPostAsync(PostDto newPost);
    }
}