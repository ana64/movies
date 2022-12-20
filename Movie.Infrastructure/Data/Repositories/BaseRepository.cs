using Movie.Core.Interfeces;
using System.Collections.Generic;
using System.Linq;

namespace Movie.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T>
    where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = ReadById(id);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
