using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingServices.Data;
using MailingServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MailingServices.Services
{
    public class EmailServices
    {
         private DbContextOptions<DbConnection> options;

        public EmailServices(DbContextOptions<DbConnection> options)
        {
            this.options = options;
        }


        public async Task SaveData(RegEmail registationEmail)
        {
            //create _context

            var _context = new DbConnection(this.options);
            _context.RegEmails.Add(registationEmail);
           await  _context.SaveChangesAsync();
        }
    }
}