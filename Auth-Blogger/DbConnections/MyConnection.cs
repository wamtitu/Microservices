using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Blogger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth_Blogger.DbConnections
{
    public class MyConnection : IdentityDbContext<AppUser>
    {
        public MyConnection(DbContextOptions<MyConnection> options):base (options){}
        
        public DbSet<AppUser> AppUsers { get; set; }
    }
}