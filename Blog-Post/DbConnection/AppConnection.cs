using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Post.DbConnection
{
    public class AppConnection : DbContext
    {
        public AppConnection(DbContextOptions<AppConnection> options):base(options)
        {
            
        }
        public DbSet<Post> Posts {get;set;}
    }
}