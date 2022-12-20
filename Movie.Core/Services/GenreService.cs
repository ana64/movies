using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;

namespace Movie.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _repository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            _repository = genreRepository;
        }

        public OperationResult<Genre> Delete(long id)
        {
            try
            {
                var genreToDelete = _repository.ReadById((int)id);
                if (genreToDelete == null) return OperationResult<Genre>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(genreToDelete.Id);
                _repository.SaveChanges();

                return OperationResult<Genre>.CreateSuccessResult(new Genre());
            }
            catch (Exception ex)
            {
                return OperationResult<Genre>.CreateFailure(ex);
            }
        }

        public OperationResult<Genre> Find(long id)
        {
            try
            {
                var category = _repository.ReadById((int)id);
                if (category == null) return OperationResult<Genre>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<Genre>.CreateSuccessResult(category);
            }
            catch (Exception ex)
            {
                return OperationResult<Genre>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<Genre>> GetAll()
        {
            try
            {
                var genres = _repository.ReadAll();

                return OperationResult<IEnumerable<Genre>>.CreateSuccessResult(genres);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Genre>>.CreateFailure(ex);
            }
        }

        public OperationResult<Genre> Save(Genre genre)
        {
            try
            {
                _repository.Create(genre);
                _repository.SaveChanges();
                return OperationResult<Genre>.CreateSuccessResult(genre);
            }
            catch (Exception ex)
            {
                return OperationResult<Genre>.CreateFailure(ex);

            }
        }

        public OperationResult<Genre> Update(Genre genre)
        {
            try
            {
                //var existingEntity = _repository.ReadById(genre.Id);
                //if (existingEntity == null) return OperationResult<Genre>.CreateFailure(new ArgumentOutOfRangeException(nameof(genre.Id)));

                _repository.Update(genre);
                _repository.SaveChanges();
                return OperationResult<Genre>.CreateSuccessResult(genre);
            }
            catch (Exception ex)
            {
                return OperationResult<Genre>.CreateFailure(ex);

            }
        }
    }
}
