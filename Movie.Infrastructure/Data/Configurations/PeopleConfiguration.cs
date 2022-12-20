using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Core.Entities;

namespace Movie.Infrastructure.Data.Configurations
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
