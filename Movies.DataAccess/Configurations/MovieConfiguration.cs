using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.DataAccess.Configurations;

namespace AspMovie.DataAccess.Configurations
{
    public class MovieConfiguration : EntityConfiguration<Movie>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.Poster).HasMaxLength(300).IsRequired(false);

            builder.HasMany(x => x.Actors)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);


        }


    }
}
