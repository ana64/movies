using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.DataAccess.Configurations;
using Movies.Domain;

namespace AspMovie.DataAccess.Configurations
{
    public abstract class PeopleConfiguration : EntityConfiguration<People>
    {
        protected override void ConfigureRules(EntityTypeBuilder<People> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(40).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
        }
    }
}
