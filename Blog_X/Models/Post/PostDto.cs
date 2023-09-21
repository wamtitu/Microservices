using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_X.Models.Post
{
    public class PostDto
    {
        public Guid PostId {get; set;}
        [Required]
        public Guid UserId {get; set;}
        [Required]
        public string Title {get; set;}
        [Required]
        public string Description {get;set;}
        public string ImageUrl {get; set;}
    }
}