using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.Models.Dtos;
using Auth_Blogger.Services.IServices;
// using AuthMailingServices;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly ResponseDto _responseDto;
        private readonly IMessageBus _messageBus;

        private readonly IConfiguration _config;

        public UserController(IUserServices userService, IConfiguration config, IMessageBus messageBus)
        {
            _userService = userService;
            _messageBus = messageBus;
            _config = config;
            _responseDto = new ResponseDto();
        }

        [HttpPost("Rgister")]
        public async Task<ActionResult<string>> RegisterUser(RegistrationDto newRegistration){
            var userResult = await _userService.RegisterUser(newRegistration);

            if(!string.IsNullOrEmpty(userResult)){
                _responseDto.IsSuccess = false;
                _responseDto.Message = userResult;

                return BadRequest(_responseDto);
            }

            //service bus
            var regQueue = _config.GetSection("QueuesandTopics:RegisterUser").Get<string>();
            var message = new UserMessage()
            {
                Email = newRegistration.Email,
                Name = newRegistration.Name,
            };
            await _messageBus.PublishMessage(message, regQueue);
            return Ok(_responseDto);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseDto>> LoginUser(LoginRequestDto newLogin){
            var response = await _userService.Login(newLogin);
             if (response.User ==null)
            {
                //error
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Invalid Credential";

                return BadRequest(_responseDto);
            }
            _responseDto.Result = response;
            return Ok(_responseDto);
        }
    }
}