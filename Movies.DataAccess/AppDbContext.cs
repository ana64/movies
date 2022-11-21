using Microsoft.EntityFrameworkCore;
using Movies.Domain;
using Movies.Domain.Entities;
using System;

namespace Movies.DataAccess
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions options)  : base(options)    {  }

        public User User { get; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = Movies; Integrated Security = True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ActorMovie>().Property(x => x.RoleName).HasMaxLength(30).IsRequired(true);
            modelBuilder.Entity<ActorMovie>().HasKey(x => new { x.MovieId, x.ActorId });
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
                            e.UpdatedBy = User?.Username;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<MovieStaff> MovieStaff { get; set; }
        public DbSet<MovieReview> MovieReview { get; set; }

    }
    
}