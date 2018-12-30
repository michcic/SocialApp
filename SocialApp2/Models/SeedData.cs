using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialApp2.Data;
using System;
using System.Linq;

namespace SocialApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Post.Any())
                {
                    return;   // DB has been seeded
                }

                context.Post.AddRange(
                    new Post
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("2018-1-12"),
                        Content = "amazing post bla bla bla bla bla",
                        Likes = 0
                    },

                    new Post
                    {
                        Title = "No title",
                        ReleaseDate = DateTime.Parse("2018-2-08"),
                        Content = "amazing post 2",
                        Likes = 0
                    },

                    new Post
                    {
                        Title = "When heheehehe",
                        ReleaseDate = DateTime.Parse("2018-2-11"),
                        Content = "amazing post 3",
                        Likes = 0
                    },

                    new Post
                    {
                        Title = "huahuahuahuah",
                        ReleaseDate = DateTime.Parse("2018-4-12"),
                        Content = "amazing post 4",
                        Likes = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
