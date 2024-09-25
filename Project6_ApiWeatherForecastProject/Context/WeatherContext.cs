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
            new City { Id = 1, Name = "İstanbul", Country = "Türkiye", Temprature = 25, Detail = "Açık" },
            new City { Id = 2, Name = "Ankara", Country = "Türkiye", Temprature = 22, Detail = "Parçalı Bulutlu" },
            new City { Id = 3, Name = "İzmir", Country = "Türkiye", Temprature = 28, Detail = "Güneşli" },
            new City { Id = 4, Name = "Berlin", Country = "Almanya", Temprature = 18, Detail = "Kapalı" },
            new City { Id = 5, Name = "Paris", Country = "Fransa", Temprature = 20, Detail = "Yağmurlu" },
            new City { Id = 6, Name = "Londra", Country = "İngiltere", Temprature = 16, Detail = "Kapalı" },
            new City { Id = 7, Name = "New York", Country = "Amerika", Temprature = 24, Detail = "Güneşli" },
            new City { Id = 8, Name = "Tokyo", Country = "Japonya", Temprature = 30, Detail = "Nemli" },
            new City { Id = 9, Name = "Moskova", Country = "Rusya", Temprature = 10, Detail = "Bulutlu" },
            new City { Id = 10, Name = "Sydney", Country = "Avustralya", Temprature = 22, Detail = "Açık" }
        );
    }
}
