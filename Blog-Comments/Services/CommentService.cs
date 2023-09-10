using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Comments.DbConnection;
using Blog_Comments.Models;
using Blog_Comments.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Blog_Comments.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppConnection _context;
        public CommentService(AppConnection context)
        {
            _context = context;
        }
        public async  Task<string> CreateCommentAsync(Comment newComment)
        {
             _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return "Blog posted succesfully";
        }

        public async Task<string> DeleteCommentAsync(Comment newComment)
        {
            _context.Comments.Remove(newComment);
            await _context.SaveChangesAsync();
            return "Post deleted successfully";
        }

        public async Task<Comment> GetCommentById(Guid Id)
        {
            return await _context.Comments.FirstOrDefaultAsync(u=>u.CommentId == Id);
        }

        public async Task<List<Comment>> GetCommentByUser(Guid id)
        {
            return await _context.Comments.Where(u=>u.UserId == id).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByPostAsync(Guid id)
        {
            return await _context.Comments.Where(u=> u.PostId == id).ToListAsync();
        }

        public async Task<string> UpdateCommentAsync(Comment newComment)
        {
            _context.Comments.Update(newComment);
            await _context.SaveChangesAsync();
            return "post updated successfully"; 
        }
    }
}