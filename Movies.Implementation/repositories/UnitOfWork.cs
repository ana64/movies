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
        }

        public IGenreRepository Genres { get; private set; }

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
