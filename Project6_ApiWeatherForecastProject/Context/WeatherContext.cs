using Microsoft.EntityFrameworkCore;
using Project6_ApiWeatherForecastProject.Entities;

public class WeatherContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-Q270QVE\\SQLEXPRESS;initial catalog=DbWeather;integrated Security=true;trustServerCertificate=true");
    }

    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(25)  
                .IsRequired();

            entity.Property(e => e.Country)
                .HasMaxLength(25) 
                .IsRequired();

            entity.Property(e => e.Detail)
                .HasMaxLength(50) 
                .IsRequired();
        });

        // Varsayılan (seed) veriler
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "İstanbul", Country = "Türkiye", Temperature = 25, Detail = "Açık" },
            new City { Id = 2, Name = "Ankara", Country = "Türkiye", Temperature = 22, Detail = "Parçalı Bulutlu" },
            new City { Id = 3, Name = "İzmir", Country = "Türkiye", Temperature = 28, Detail = "Güneşli" },
            new City { Id = 4, Name = "Berlin", Country = "Almanya", Temperature = 18, Detail = "Kapalı" },
            new City { Id = 5, Name = "Paris", Country = "Fransa", Temperature = 20, Detail = "Yağmurlu" },
            new City { Id = 6, Name = "Londra", Country = "İngiltere", Temperature = 16, Detail = "Kapalı" },
            new City { Id = 7, Name = "New York", Country = "Amerika", Temperature = 24, Detail = "Güneşli" },
            new City { Id = 8, Name = "Tokyo", Country = "Japonya", Temperature = 30, Detail = "Nemli" },
            new City { Id = 9, Name = "Moskova", Country = "Rusya", Temperature = 10, Detail = "Bulutlu" },
            new City { Id = 10, Name = "Sydney", Country = "Avustralya", Temperature = 22, Detail = "Açık" }
        );
    }
}
