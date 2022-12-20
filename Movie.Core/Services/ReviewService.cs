using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<MovieReview> _repository;

        public ReviewService(IRepository<MovieReview> ReviewRepository)
        {
            _repository = ReviewRepository;
        }

        public OperationResult<MovieReview> Delete(long id)
        {
            try
            {
                var ReviewToDelete = _repository.ReadById((int)id);
                if (ReviewToDelete == null) return OperationResult<MovieReview>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(ReviewToDelete.MovieId);
                _repository.SaveChanges();

                return OperationResult<MovieReview>.CreateSuccessResult(new MovieReview());
            }
            catch (Exception ex)
            {
                return OperationResult<MovieReview>.CreateFailure(ex);
            }
        }

        public OperationResult<MovieReview> Find(long id)
        {
            try
            {
                var Review = _repository.ReadById((int)id);
                if (Review == null) return OperationResult<MovieReview>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<MovieReview>.CreateSuccessResult(Review);
            }
            catch (Exception ex)
            {
                return OperationResult<MovieReview>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<MovieReview>> GetAll()
        {
            try
            {
                var Reviews = _repository.ReadAll();

                return OperationResult<IEnumerable<MovieReview>>.CreateSuccessResult(Reviews);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<MovieReview>>.CreateFailure(ex);
            }
        }

        public OperationResult<MovieReview> Save(MovieReview Review)
        {
            try
            {
                _repository.Create(Review);
                _repository.SaveChanges();
                return OperationResult<MovieReview>.CreateSuccessResult(Review);
            }
            catch (Exception ex)
            {
                return OperationResult<MovieReview>.CreateFailure(ex);

            }
        }

        public OperationResult<MovieReview> Update(MovieReview Review)
        {
            try
            {

                _repository.Update(Review);
                _repository.SaveChanges();
                return OperationResult<MovieReview>.CreateSuccessResult(Review);
            }
            catch (Exception ex)
            {
                return OperationResult<MovieReview>.CreateFailure(ex);

            }
        }
    }
}
