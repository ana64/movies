using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Core.Entities;

namespace Movie.Infrastructure.Data.Configurations
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
