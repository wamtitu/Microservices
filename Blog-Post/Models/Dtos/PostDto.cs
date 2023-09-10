using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Post.Models.Dtos
{
    public class PostDto
    {
        [Required]
        public Guid UserId {get; set;}
        [Required]
        public string Title {get; set;}
        [Required]
        public string Description {get;set;}
    }
}