using Microsoft.EntityFrameworkCore;
using Movie.Core.Entities;
using Movie.Core.Interfeces;
using System;

namespace Movie.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //{

        //}
        public AppDbContext(DbContextOptions options) : base(options) { }

        public IApplicationUser User { get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Movie;Integrated Security=True")
        //        .UseLazyLoadingProxies(); ;               
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ActorMovie>().Property(x => x.RoleName).HasMaxLength(30).IsRequired(true);
            modelBuilder.Entity<ActorMovie>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<GenreMovie>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<MovieStaff>().HasKey(x => new { x.JobId, x.StaffId, x.MovieId });
            modelBuilder.Entity<MovieReview>().HasKey(x => new { x.UserId, x.MovieId });
            modelBuilder.Entity<MovieReview>().Property(x => x.Rate).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<MovieReview>().Property(x => x.Comment).HasMaxLength(300).IsRequired(false);


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Core.Entities.Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<MovieStaff> MovieStaff { get; set; }
        public DbSet<MovieReview> MovieReview { get; set; }

    }

}

