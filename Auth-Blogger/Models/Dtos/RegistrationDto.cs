using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Blogger.Models.Dtos
{
    public class RegistrationDto
    {
        [Required]
        public string Email { get; set; }=string.Empty;
        [Required]
        public string Password { get; set; }=string.Empty;
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required]
        public string PhoneNumber { get; set; }=string.Empty;
        public string? Role { get; set; }=string.Empty;
    }
}