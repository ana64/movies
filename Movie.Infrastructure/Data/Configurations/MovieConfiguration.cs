using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movie.Infrastructure.Data.Configurations
{
    public class MovieConfiguration : EntityConfiguration<Core.Entities.Movie>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Core.Entities.Movie> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.Poster).HasMaxLength(300).IsRequired(false);

            builder.HasMany(x => x.Actors)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Genres)
                 .WithOne(x => x.Movie)
                 .HasForeignKey(x => x.MovieId)
                 .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
