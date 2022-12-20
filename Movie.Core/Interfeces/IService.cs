using Movie.Core.Shered.Results;
using System.Collections.Generic;

namespace Movie.Core.Interfeces
{
    public interface IService<T>
    {
         OperationResult<IEnumerable<T>> GetAll();
         OperationResult <T> Find(long id);
         OperationResult <T> Save(T entity);
         OperationResult <T> Update(T entity);
         OperationResult<T> Delete(long id);

    }
}
