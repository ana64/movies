using Movies.Application.interfeces;
using Movies.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Implementation.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Genres = new GenreRepository(_context);
            Jobs = new JobRepository(_context);
            Actors = new ActorRepository(_context);
            Staffs = new StaffRepository(_context);
            Movies = new MovieRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public IGenreRepository Genres { get; private set; }

        public IJobRepository Jobs { get; private set; }

        public IStaffRepository Staffs { get; private set; }

        public IActorRepository Actors { get; private set; }

        public IMovieRepository Movies { get; private set; }

        public IReviewRepository Reviews { get; private set; }

        public void Dispose()
        {
           _context.Dispose();
        }
        public int Save()
        {
          return  _context.SaveChanges();
        }
    }
}
