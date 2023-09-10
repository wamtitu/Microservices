using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.Models;
using Blog_Post.Services.IServices;
using Newtonsoft.Json;

namespace Blog_Post.Services
{
    public class CommentService : ICommentsService
    {

        private readonly IHttpClientFactory _clientFactory;
        public CommentService(IHttpClientFactory clientFactory){
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            
            try
            {
                var client = _clientFactory.CreateClient("Comment");
                var response = await client.GetAsync("api/Comment/post");
                var content = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);

                if (responseDto.IsSuccess)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<Comment>>(Convert.ToString(responseDto.Result));
                }
                
            }
            catch (System.Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            return new List<Comment>();
        }
    }
}