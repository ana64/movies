using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Core.Entities;

namespace Movie.Infrastructure.Data.Configurations
{ 
    public class GenreConfication : EntityConfiguration<Genre>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(x=>x.Name).IsUnique();

            builder.HasMany(x => x.Movies)
                  .WithOne(x => x.Genre)
                  .HasForeignKey(x => x.GenreId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
