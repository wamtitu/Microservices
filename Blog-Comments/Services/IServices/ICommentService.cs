using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Comments.Models;

namespace Blog_Comments.Services.IServices
{
    public interface ICommentService
    {
        Task<string> CreateCommentAsync(Comment newComment);
        Task<string> DeleteCommentAsync(Comment newComment);
        Task<string> UpdateCommentAsync(Comment newComment);
        Task<List<Comment>> GetCommentsByPostAsync(Guid id);
        Task <Comment> GetCommentById(Guid Id);
        Task<List<Comment>> GetCommentByUser(Guid id);
    }
}