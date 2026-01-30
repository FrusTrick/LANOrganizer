
using LANOrganizer.Data;
using LANOrganizer.Endpoints;
using LANOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using LANOrganizer.Data.Services;

namespace LANOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<LanorgDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddHttpClient<ISteamGameResponseService, SteamGameResponse>(s =>
            {
                s.BaseAddress = new Uri(builder.Configuration["SteamApi:BaseUrl"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Theme = ScalarTheme.BluePlanet;
                });

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           LanorgEndpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}
