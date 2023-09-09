using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingServices.Data;
using Microsoft.EntityFrameworkCore;

namespace MailingServices.Extensions
{
    public static class AddMigrations
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<DbConnection>();
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }

            return app;
        }
    }
}