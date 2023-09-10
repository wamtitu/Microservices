using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Comments.Models.Dtos
{
    public class CommentDto
    {
        public Guid UserId {get;set;}
        public string CommentDesc {get;set;}
        public Guid PostId {get;set;}
    }
}