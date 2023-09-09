using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MailingServices.Data
{
    public class DbConnection : DbContext
    {
         public DbConnection(DbContextOptions<DbConnection> options):base(options)
        {
            
        }

        public DbSet<RegEmail> RegEmails { get; set; }
    }
}