using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Blog_Comments.Models;
using Blog_Comments.Models.Dtos;
using Blog_Comments.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Comments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        
        [HttpPost("AddComment")]
        [Authorize]
        public async Task<ActionResult<string>> CreateComment(CommentDto newComment){
            try
            {
                 var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            System.Console.WriteLine(id);
            if(id != null){
                newComment.UserId  = Guid.Parse(id);
                var post = _mapper.Map<Comment>(newComment);
                var response = await _commentService.CreateCommentAsync(post);
                return Ok(response);
            }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return "Invalid user";
            
        }

         [HttpGet("GetCommentsByUSer/{id}")]
        public async Task<ActionResult<List<Comment>>> GetPosts(Guid id){
            var comments = await _commentService.GetCommentByUser(id);
            if(comments==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message= "no comments";

                return BadRequest(_responseDto);
            }

            _responseDto.Result = comments;
            return Ok(_responseDto);
        }

         [HttpGet("oneComment")]

        public async Task<ActionResult<Comment>> GetAPost(Guid Id){
            var comment = await _commentService.GetCommentById(Id);
            if(comment == null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "invalid id";

                return BadRequest(_responseDto);
            }

            _responseDto.Result = comment;
            return Ok(_responseDto);
        }
         [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeletePost(Guid Id){
            var toDelete = await _commentService.GetCommentById(Id);
            if(toDelete==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no post with specified id";

                return BadRequest(_responseDto);
            }
            var deleted = await _commentService.DeleteCommentAsync(toDelete);
            _responseDto.Message = deleted;
            return Ok(_responseDto);

        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<ActionResult<string>> UpdatePost(CommentDto updated, Guid Id){
            var toUpdate = await _commentService.GetCommentById(Id);
            if(toUpdate==null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no comment with specified id";

                return BadRequest(_responseDto);
            }
            var comment = _mapper.Map(updated, toUpdate);
            var update = await _commentService.UpdateCommentAsync(comment);

            _responseDto.Message = update;
            return Ok(_responseDto);
        }

        [HttpGet("post/{id}")]
        public async Task<ActionResult<List<Comment>>> GetuserPosts(Guid id){
            var comments = await _commentService.GetCommentsByPostAsync(id);
            if(comments == null){
                _responseDto.IsSuccess = false;
                _responseDto.Message = "no comments found";

                return BadRequest(_responseDto);
            }
            // _responseDto.Result=comments;
            return Ok(comments);
        }
    }
}