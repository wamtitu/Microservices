using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_X.Models.Commntsf
{
    public class CommentRequest
    {
        public Guid UserId {get;set;}
        public string CommentDesc {get;set;}
        public Guid PostId {get;set;}
    }
}