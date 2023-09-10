using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Comments.Models.Dtos
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}