using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.DataAccess.Configurations;
using Movies.Domain.Entities;

namespace AspMovie.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {

        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();


        }
    }
}
