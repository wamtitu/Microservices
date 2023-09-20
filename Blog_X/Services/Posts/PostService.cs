using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<string> AddPostAsync(PostDto newPost)
        {
            var request = JsonConvert.SerializeObject(newPost);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/api/Post/Addpost", body);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
           

            if(content !=null){
                return content;
            }
            return "error occures";

        }

        public Task<ResponseDto> DeletePostAsync(PostDto deletePost)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostByIdAsync(Guid Id)
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