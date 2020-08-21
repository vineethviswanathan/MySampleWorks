using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyDBContext>>()))
            {
                // Look for any movies.
                if (context.Locations.Any())
                {
                    return;   // DB has been seeded
                }

                context.Locations.AddRange(
                    new Location
                    {
                         Address="Old Delhi Market",
                           City="Delhi",
                            State="Delhi"
                    },
                    new Location
                    {
                        Address = "South Beach",
                        City = "Miami",
                        State = "Florida"
                    },
                    new Location
                    {
                        Address = "Fort Lauderdale",
                        City = "Miami",
                        State = "Florida"
                    },
                    new Location
                    {
                        Address = "Fort Worth",
                        City = "dallas",
                        State = "Texas"
                    }
                    ,
                    new Location
                    {
                        Address = "North Fort",
                        City = "Miami Beach",
                        State = "Florida"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
