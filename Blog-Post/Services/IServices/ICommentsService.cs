using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.Models;

namespace Blog_Post.Services.IServices
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
    }
}