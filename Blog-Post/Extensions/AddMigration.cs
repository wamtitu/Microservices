using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Post.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace Blog_Post.Extensions
{
    public static class AddMigration
    {
          public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppConnection>();
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }

            return app;
        }
    }
}