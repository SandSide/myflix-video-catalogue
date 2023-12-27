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
            new Video { Id = 0, Title = "C Technical", Description = "Old dude write something", Author = "Pexels", Length = 41, VideoUrl = "pexels-c-technical.mp4" },
            new Video { Id = 0, Title = "Nicole Michalou", Description = "Christmas table", Author = "Pexels", Length = 15, VideoUrl = "pexels-nicole-michalou.mp4" },
            new Video { Id = 0, Title = "Olia Danilevich.mp4", Description = "Place stickynotes", Author = "Pexels", Length = 17, VideoUrl = "pexels-olia-danilevich.mp4" },
            new Video { Id = 0, Title = "Ron Lach", Description = "Interact with drawing tablet", Author = "Pexels", Length = 33, VideoUrl = "pexels-ron-lach.mp4" },
            new Video { Id = 0, Title = "Production", Description = "Creating clay vase", Author = "Pexels", Length = 8, VideoUrl = "production_id.mp4" }
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
