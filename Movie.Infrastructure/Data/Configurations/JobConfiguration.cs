using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Infrastructure.Data.Configurations;
using Movie.Core.Entities;

namespace Movies.DataAccess.Configurations
{
    public class JobConfiguration : EntityConfiguration<Job>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Job> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.HasIndex(x=>x.Name).IsUnique();

            builder.HasData(
                 new Job { Id=1,Name ="Director",CreatedAt=System.DateTime.UtcNow},
                 new Job { Id=2,Name = "Producer", CreatedAt = System.DateTime.UtcNow },
                 new Job {Id=3, Name = "Screenplay" , CreatedAt = System.DateTime.UtcNow },
                 new Job {Id = 4, Name = "Script",CreatedAt = System.DateTime.UtcNow }
                );
        }
    }
}
