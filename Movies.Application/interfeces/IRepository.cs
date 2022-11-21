using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.interfeces
{
    public interface IRepository <T>
    {
        IEnumerable<T> ReadAll();
        T ReadById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
