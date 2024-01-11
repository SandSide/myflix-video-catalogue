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

    }
}
