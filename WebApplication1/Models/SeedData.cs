using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.Bikes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bikes.AddRange(
                    new Bikes
                    {
                        Name = "A bike",
                        Rides = 15
                    },
                    new Bikes
                    {
                        Name = "Another bike",
                        Rides = 8
                    },
                    new Bikes
                    {
                        Name = "A Third bike",
                        Rides = 5
                    },
                    new Bikes
                    {
                        Name = "lAst bike",
                        Rides = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
