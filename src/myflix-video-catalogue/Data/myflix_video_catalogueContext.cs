using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myflix_video_catalogue.Models;

namespace myflix_video_catalogue.Data
{
    public class myflix_video_catalogueContext : DbContext
    {
        public myflix_video_catalogueContext (DbContextOptions<myflix_video_catalogueContext> options)
            : base(options)
        {
        }

        public DbSet<myflix_video_catalogue.Models.Video> Video { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasData(
                    new Video { Id = 1, Title = "Shrek", Description = "Good Movie", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek" },
                    new Video { Id = 2, Title = "Shrek 2", Description = "I need a Heeeeeeeeeerorooooooo!", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek2" },
                    new Video { Id = 3, Title = "Shrek 3", Description = "???", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek3" }
                );
        }
    }
}
