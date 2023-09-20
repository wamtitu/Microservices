using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Post.Models;
using Blog_Post.Models.Dtos;
using Blog_Post.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Post.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postservice;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postservice = postService;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpPost("Addpost")]
        [Authorize]
        public async Task<ActionResult<string>> CreatePost(PostDto newPost){
            var post = _mapper.Map<Post>(newPost);
            var response = await _postservice.CreatePostAsync(post);
            return Ok(response);
        }

        [HttpGet("GetPosts")]
        public async Task<ActionResult<List<Post>>> GetPosts(){
            var posts = await _postservice.GetPostsAsync();
            if(posts==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message= "no posts";

                return BadRequest(_responseDto);
            }

            _responseDto.Result = posts;
            return Ok(_responseDto);
        }

        [HttpGet("onePost")]

        public async Task<ActionResult<Post>> GetAPost(Guid Id){
            var post = await _postservice.GetPostById(Id);
            if(post == null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "invalid id";

                return BadRequest(_responseDto);
            }
            Console.WriteLine(post.Comments.Count);

            _responseDto.Result = post;
            return Ok(_responseDto);
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeletePost(Guid Id){
            var toDelete = await _postservice.GetPostById(Id);
            if(toDelete==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no post with specified id";

                return BadRequest(_responseDto);
            }
            var deleted = await _postservice.DeletePostAsync(toDelete);
            _responseDto.Message = deleted;
            return Ok(_responseDto);

        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<ActionResult<string>> UpdatePost(PostDto updated, Guid Id){
            var toUpdate = await _postservice.GetPostById(Id);
            if(toUpdate==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no post with specified id";

                return BadRequest(_responseDto);
            }
            var post = _mapper.Map(updated, toUpdate);
            var update = await _postservice.UpdatePostAsync(post);
            _responseDto.Message = update;
            return Ok(_responseDto);
        }

        [HttpGet("user{id}")]
        public async Task<ActionResult<List<Post>>> GetuserPosts(Guid id){
            var posts = await _postservice.GetUSersPosts(id);
            if(posts == null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no posts found";

                return BadRequest(_responseDto);
            }
            _responseDto.Result=posts;
            return Ok(_responseDto);
        }
    }
}