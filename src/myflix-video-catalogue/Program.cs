using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myflix_video_catalogue.Data;
using myflix_video_catalogue.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<myflix_video_catalogueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myflix_video_catalogueContext") ?? throw new InvalidOperationException("Connection string 'myflix_video_catalogueContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database is created and populated
using (var scope = app.Services.CreateScope())
{
    // Try to migrate db
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<myflix_video_catalogueContext>();
    context.Database.Migrate();

    // Seed db if it dose not have any videos
    if (!context.Video.Any())
    {
        Console.WriteLine("Seeding db");

        context.Video.AddRange(
            new Video { Id = 0, Title = "Shrek", Description = "Good Movie", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek" },
            new Video { Id = 0, Title = "Shrek 2", Description = "I need a Heeeeeeeeeerorooooooo!", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek2" },
            new Video { Id = 0, Title = "Shrek 3", Description = "???", Author = "Disney", Length = 120, VideoUrl = "www.example.com/Shrek3" }
        );

        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving changes: {ex}");
        }

    }
    else
    {
        Console.WriteLine("db already has data, not seeding");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
