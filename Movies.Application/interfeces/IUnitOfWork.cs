using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.interfeces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenreRepository Genres { get; }

        int Save();
    }
}
