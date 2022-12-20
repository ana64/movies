using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Core.Entities;

namespace Movie.Infrastructure.Data.Configurations
{
    public class ActorConfiguration : EntityConfiguration<Actor>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Actor> builder)
        {

            builder.Property(x => x.Biography).HasMaxLength(250).IsRequired(false);

            builder.HasMany(x => x.ActorMovie)
                   .WithOne(x => x.Actor)
                   .HasForeignKey(x => x.ActorId)
                   .OnDelete(DeleteBehavior.Restrict);

        }


    }




}
