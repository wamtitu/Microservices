using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Post.Models
{
    public class Post
    {
        public Guid PostId {get; set;}
        public Guid UserId {get; set;}
        public string Title {get; set;}
        public string Description {get;set;}
        public DateTime postedOn {get;set;} = DateTime.Now;
        public List<Comment> Comments {get;set;}= new List<Comment>();
    }
}