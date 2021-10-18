using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testsite.Data;
using System;
using System.Linq;

namespace Testsite.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestsiteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestsiteContext>>()))
            {
                // Look for any movies.
                if (context.Motorcycle.Any())
                {
                    return;   // DB has been seeded
                }

                context.Motorcycle.AddRange(
                    new Motorcycle
                    {
                        Name = "Fatbob",
                        ReleaseDate = DateTime.Parse("2018-2-12"),
                        Type = "Softtail",
                        Price = 21000,
                        Engine = "Milwaukee-8 107"
                    },

                    new Motorcycle
                    {
                        Name = "Iron 883 ",
                        ReleaseDate = DateTime.Parse("2017-3-13"),
                        Type = "Sportster",
                        Price = 12000,
                        Engine = "Milwaukee-8 107"
                    },

                    new Motorcycle
                    {
                        Name = "Sportster S",
                        ReleaseDate = DateTime.Parse("2021-2-23"),
                        Type = "Sportster",
                        Price = 14999,
                        Engine = "Milwaukee-8 107"
                    },

                    new Motorcycle
                    {
                        Name = "Pan America",
                        ReleaseDate = DateTime.Parse("2021-4-15"),
                        Type = "Semi-Off Road",
                        Price = 17319,
                        Engine = "Milwaukee-8 107"
                    } 
                );
                context.SaveChanges();
            }
        }
    }
}