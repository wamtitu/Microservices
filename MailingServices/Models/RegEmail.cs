using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingServices.Models
{
    public class RegEmail
    {
         public Guid Id { get; set; }

        public string Email { get; set; }=string.Empty;

        public string Message {  get; set; }=string.Empty;

        public DateTime Created { get; set; }=DateTime.Now;
    }
}