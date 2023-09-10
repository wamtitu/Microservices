using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Post.Models
{
    public class Comment
    {
        public Guid CommentId {get;set;}
        public Guid UserId {get;set;}
        public string CommentDesc {get;set;}
        public Guid PostId {get;set;}

        [NotMapped]
        public Post Post {get;set;}
    }
}