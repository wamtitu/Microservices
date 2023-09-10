using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Comments.Models
{
    public class Comment
    {
        public Guid CommentId {get;set;}
        public Guid UserId {get;set;}
        public string CommentDesc {get;set;}
        public Guid PostId {get;set;}
        public DateTime craetedAt {get; set;} = DateTime.Now;
    }
}