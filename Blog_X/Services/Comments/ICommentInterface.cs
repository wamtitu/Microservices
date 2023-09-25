using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_X.Models.Commntsf;

namespace Blog_X.Services.Comments
{
    public interface ICommentInterface
    {
        Task<List<Comment>> GetComments(Guid id);
        Task<string> AddComment(CommentRequest newComment);
    }
}