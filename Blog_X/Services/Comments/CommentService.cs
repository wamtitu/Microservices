using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_X.Models.Commntsf;
using Blog_X.Models;
using Newtonsoft.Json;

namespace Blog_X.Services.Comments
{
    public class CommentService : ICommentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://localhost:5252";
        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Comment>> GetComments(Guid id)
        {
            var res = await _httpClient.GetAsync($"{BaseUrl}/api/Comment/post/{id}");
            var response = await res.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(response);
            if(result != null){
                return JsonConvert.DeserializeObject<List<Comment>>(result.Result.ToString());
                
            }
            return new List<Comment>();
        }
        public async Task<string> AddComment(CommentRequest newComment){
            var request = JsonConvert.SerializeObject(newComment);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/api/Comment/AddComment", body);
            var content = await response.Content.ReadAsStringAsync();
           

            if(content !=null){
                return content;
            }
            return "error occured while adding the comment";
        }
    }
}