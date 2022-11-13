using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Movies.DataAccess.Configurations
{
    public class GenreConfication : EntityConfiguration<Genre>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(x=>x.Name).IsUnique();

            builder.HasData(
                   new Genre {Id = 1, Name = "Action", CreatedAt = System.DateTime.UtcNow },
                   new Genre {Id = 2, Name = "Comedy" , CreatedAt = System.DateTime.UtcNow },
                   new Genre {Id = 3, Name = "Romance" , CreatedAt = System.DateTime.UtcNow },
                   new Genre {Id = 4, Name = "Drama", CreatedAt = System.DateTime.UtcNow }
                );
                       
        }
    }
}
