using Movies.Application.interfeces;
using Movies.DataAccess;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Implementation.repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
