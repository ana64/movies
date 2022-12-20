using System.Collections.Generic;

namespace Movie.Core.Interfeces
{
    public interface IRepository <T>
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        int SaveChanges();
    }
}
