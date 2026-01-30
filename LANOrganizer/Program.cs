using LANOrganizer.Data;
using LANOrganizer.Data.Services;
using LANOrganizer.Endpoints;
using LANOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;


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


            builder.Services.AddHttpClient<ISteamGameResponseService, SteamGameResponseService>(s =>
            {
                s.BaseAddress = new Uri(builder.Configuration["SteamApi:BaseUrl"]);
            });

            builder.Services.AddHttpClient<ISteamUserResponseService, SteamUserResponseService>(s =>
            {
                s.BaseAddress = new Uri(builder.Configuration["SteamApi:BaseUrl"]); 
            });

            builder.Services.AddTransient<LanorgEndpoints>();

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

            
            var lanorgEndpoints = app.Services.GetRequiredService<LanorgEndpoints>();
            lanorgEndpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}
