using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models.Entities
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBNAContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DBNAContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        ID = 1,
                        UserName = "hoang",
                        Password = "hoang",
                        Gender = 1,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
