using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_X.Models;
using Blog_X.Models.Auth;
using Newtonsoft.Json;

namespace Blog_X.Services.Authentication
{
    public class AuthService : IAuthInteface
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "https://auth-bloggerapi.azurewebsites.net";
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponseDto> Login(LoginDto newLogin)
        {
            var request = JsonConvert.SerializeObject(newLogin);
            var body = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/api/User/Login", body);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseDto>(content);
            if(result.IsSuccess){
                return JsonConvert.DeserializeObject<LoginResponseDto>(result.Result.ToString());
            }

            return new LoginResponseDto();
        }

        public async Task<ResponseDto> Register(RegisterDto newRegister)
        {
            var request = JsonConvert.SerializeObject(newRegister);
            var body = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/api/User/Rgister", body);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(content);

            if(result.IsSuccess){
                return result;
            }
            return new ResponseDto();
        }
    }
}