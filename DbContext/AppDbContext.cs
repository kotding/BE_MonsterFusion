using Microsoft.EntityFrameworkCore;
using MonsterFusion_BE.Features.WeatherForecast.Entity;

namespace MonsterFusion_BE
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
