using MovieDatabaseAPI.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace MovieDatabaseAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RequestCount> RequestCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Actor>()
                .HasMany(m => m.Movies)
                .WithMany(a => a.Actors);

            modelBuilder.Entity<Movie>()
                .HasMany(a => a.Actors)
                .WithMany(m => m.Movies);

            base.OnModelCreating(modelBuilder);

        }
    }
}
