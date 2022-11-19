using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.interfaces
{
    public interface IRepository <T,K>
    {
       List<T> Read();
        T ReadById<T>(K id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
