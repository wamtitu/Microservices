using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Comments.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Comments.DbConnection
{
    public class AppConnection : DbContext
    {
        public AppConnection(DbContextOptions<AppConnection> options):base(options)
        {
            
        }
        public DbSet<Comment> Comments {get;set;}
    }
}