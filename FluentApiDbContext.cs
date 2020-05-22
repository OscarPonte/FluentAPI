using System.Data.Entity;
using FluentAPI.EntityConfigurations;

namespace FluentAPI
{
    public class FluentApiDbContext : DbContext
    {
        public FluentApiDbContext()
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());

        }
    }
}

