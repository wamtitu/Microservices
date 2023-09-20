using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_X.Models;
using Blog_X.Models.Post;
using Newtonsoft.Json;

namespace Blog_X.Services.Posts
{
    public class PostService : IPostInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://localhost:5003";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<ResponseDto> AddPostAsync(PostDto newPost)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeletePostAsync(PostDto deletePost)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetPostByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostDto>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/Post/GetPosts");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if(results.IsSuccess){
                return JsonConvert.DeserializeObject<List<PostDto>>(results.Result.ToString());
            }
            return new List<PostDto>();
        }

        public Task<ResponseDto> UpdatePostAsync(PostDto UpdatedPost)
        {
            throw new NotImplementedException();
        }
    }
}