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
        // private readonly string BaseUrl = "http://localhost:5003";
        private readonly string BaseUrl = "https://communicationgateway.azurewebsites.net";

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

        public async Task<ResponseDto> DeletePostAsync(Guid id)
        {
            var res = await _httpClient.DeleteAsync($"{BaseUrl}/api/Post/{id}");
            var content = await res.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDto>(content.ToString());
            if (results.IsSuccess)
            {
                
                return results;

            }

            return new ResponseDto();
        }

        public async Task<PostDto> GetPostByIdAsync(Guid Id)
        {
           var response = await _httpClient.GetAsync($"{BaseUrl}/api/Post/onePost?Id={Id}");
           var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content.ToString());
            if(results.IsSuccess){
                return JsonConvert.DeserializeObject<PostDto>(results.Result.ToString());
            }
            return new PostDto();

        }

        public async Task<List<PostDto>> GetPostByUserIdAsync(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/Post/user{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if(results.IsSuccess){
                return JsonConvert.DeserializeObject<List<PostDto>>(results.Result.ToString());
            }
            return new List<PostDto>();
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

        public async Task<ResponseDto> UpdatePostAsync(Guid id, PostDto UpdatedPost)
        {
            var request = JsonConvert.SerializeObject(UpdatedPost);

            var body = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BaseUrl}/api/Post/{id}", body);
            var content = response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(content.Result.ToString());
            if(res.IsSuccess){
                return res;
            }
            return new ResponseDto();
        }
    }
}