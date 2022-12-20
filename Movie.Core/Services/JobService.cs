using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;

namespace Movie.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _repository;

        public JobService(IRepository<Job> JobRepository)
        {
            _repository = JobRepository;
        }

        public OperationResult<Job> Delete(long id)
        {
            try
            {
                var JobToDelete = _repository.ReadById((int)id);
                if (JobToDelete == null) return OperationResult<Job>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(JobToDelete.Id);
                _repository.SaveChanges();

                return OperationResult<Job>.CreateSuccessResult(new Job());
            }
            catch (Exception ex)
            {
                return OperationResult<Job>.CreateFailure(ex);
            }
        }

        public OperationResult<Job> Find(long id)
        {
            try
            {
                var job = _repository.ReadById((int)id);
                if (job == null) return OperationResult<Job>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<Job>.CreateSuccessResult(job);
            }
            catch (Exception ex)
            {
                return OperationResult<Job>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<Job>> GetAll()
        {
            try
            {
                var Jobs = _repository.ReadAll();

                return OperationResult<IEnumerable<Job>>.CreateSuccessResult(Jobs);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Job>>.CreateFailure(ex);
            }
        }

        public OperationResult<Job> Save(Job Job)
        {
            try
            {
                _repository.Create(Job);
                _repository.SaveChanges();
                return OperationResult<Job>.CreateSuccessResult(Job);
            }
            catch (Exception ex)
            {
                return OperationResult<Job>.CreateFailure(ex);

            }
        }

        public OperationResult<Job> Update(Job Job)
        {
            try
            {
                //var existingEntity = _repository.ReadById(Job.Id);
                //if (existingEntity == null) return OperationResult<Job>.CreateFailure(new ArgumentOutOfRangeException(nameof(Job.Id)));

                _repository.Update(Job);
                _repository.SaveChanges();
                return OperationResult<Job>.CreateSuccessResult(Job);
            }
            catch (Exception ex)
            {
                return OperationResult<Job>.CreateFailure(ex);

            }
        }
    }
}
