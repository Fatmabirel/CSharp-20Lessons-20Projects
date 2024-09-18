using Project4_EntityFrameworkCodeFirstMovieProject.DAL.Entities;
using System.Data.Entity;

namespace Project4_EntityFrameworkCodeFirstMovieProject.DAL.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
