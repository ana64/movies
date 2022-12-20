using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;




namespace Movie.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie.Core.Entities.Movie> _repository;

        public MovieService(IRepository<Movie.Core.Entities.Movie> MovieRepository)
        {
            _repository = MovieRepository;
        }

        public OperationResult<Movie.Core.Entities.Movie> Delete(long id)
        {
            try
            {
                var MovieToDelete = _repository.ReadById((int)id);
                if (MovieToDelete == null) return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(MovieToDelete.Id);
                _repository.SaveChanges();

                return OperationResult<Movie.Core.Entities.Movie>.CreateSuccessResult(new  Movie.Core.Entities.Movie());
            }
            catch (Exception ex)
            {
                return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(ex);
            }
        }

        public OperationResult<Movie.Core.Entities.Movie> Find(long id)
        {
            try
            {
                var movie = _repository.ReadById((int)id);
                if (movie == null) return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<Movie.Core.Entities.Movie>.CreateSuccessResult(movie);
            }
            catch (Exception ex)
            {
                return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<Movie.Core.Entities.Movie>> GetAll()
        {
            try
            {
                var Movies = _repository.ReadAll();

                return OperationResult<IEnumerable<Movie.Core.Entities.Movie>>.CreateSuccessResult(Movies);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Movie.Core.Entities.Movie>>.CreateFailure(ex);
            }
        }

        public OperationResult<Movie.Core.Entities.Movie> Save(Movie.Core.Entities.Movie movie)
        {
            try
            {
                _repository.Create(movie);
                _repository.SaveChanges();
                return OperationResult<Movie.Core.Entities.Movie>.CreateSuccessResult(movie);
            }
            catch (Exception ex)
            {
                return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(ex);

            }
        }

        public OperationResult<Movie.Core.Entities.Movie> Update(Movie.Core.Entities.Movie movie)
        {
            try
            {
                //var existingEntity = _repository.ReadById(Movie.Id);
                //if (existingEntity == null) return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(new ArgumentOutOfRangeException(nameof(Movie.Id)));

                _repository.Update(movie);
                _repository.SaveChanges();
                return OperationResult<Movie.Core.Entities.Movie>.CreateSuccessResult(movie);
            }
            catch (Exception ex)
            {
                return OperationResult<Movie.Core.Entities.Movie>.CreateFailure(ex);

            }
        }
    }
}
