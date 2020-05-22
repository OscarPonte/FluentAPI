
using System.Data.Entity.ModelConfiguration;

namespace FluentAPI.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            HasMany(m => m.Tags)
                .WithMany(t => t.Movies)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("MovieId");
                    m.MapRightKey("TagId");
                });
        }
    }
}
