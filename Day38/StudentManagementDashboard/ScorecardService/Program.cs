
using Microsoft.EntityFrameworkCore;
using ScorecardService.Models;

namespace ScorecardService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ScoreCardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddHttpClient("StudentService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7241/");
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/", () => Results.Redirect("/swagger"));

            app.MapControllers();

            app.Run();
        }
    }
}