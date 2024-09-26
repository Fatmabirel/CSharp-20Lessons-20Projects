﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Project6_ApiWeatherForecastProject.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project6_ApiWeatherForecastProject.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Temprature")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Türkiye",
                            Detail = "Açık",
                            Name = "İstanbul",
                            Temprature = 25m
                        },
                        new
                        {
                            Id = 2,
                            Country = "Türkiye",
                            Detail = "Parçalı Bulutlu",
                            Name = "Ankara",
                            Temprature = 22m
                        },
                        new
                        {
                            Id = 3,
                            Country = "Türkiye",
                            Detail = "Güneşli",
                            Name = "İzmir",
                            Temprature = 28m
                        },
                        new
                        {
                            Id = 4,
                            Country = "Almanya",
                            Detail = "Kapalı",
                            Name = "Berlin",
                            Temprature = 18m
                        },
                        new
                        {
                            Id = 5,
                            Country = "Fransa",
                            Detail = "Yağmurlu",
                            Name = "Paris",
                            Temprature = 20m
                        },
                        new
                        {
                            Id = 6,
                            Country = "İngiltere",
                            Detail = "Kapalı",
                            Name = "Londra",
                            Temprature = 16m
                        },
                        new
                        {
                            Id = 7,
                            Country = "Amerika",
                            Detail = "Güneşli",
                            Name = "New York",
                            Temprature = 24m
                        },
                        new
                        {
                            Id = 8,
                            Country = "Japonya",
                            Detail = "Nemli",
                            Name = "Tokyo",
                            Temprature = 30m
                        },
                        new
                        {
                            Id = 9,
                            Country = "Rusya",
                            Detail = "Bulutlu",
                            Name = "Moskova",
                            Temprature = 10m
                        },
                        new
                        {
                            Id = 10,
                            Country = "Avustralya",
                            Detail = "Açık",
                            Name = "Sydney",
                            Temprature = 22m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}