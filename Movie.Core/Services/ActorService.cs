using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;


namespace Movie.Core.Services
{
     public class ActorService : IActorService
    {
        private readonly IRepository<Actor> _repository;

        public ActorService(IRepository<Actor> ActorRepository)
        {
            _repository = ActorRepository;
        }

        public OperationResult<Actor> Delete(long id)
        {
            try
            {
                var ActorToDelete = _repository.ReadById((int)id);
                if (ActorToDelete == null) return OperationResult<Actor>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(ActorToDelete.Id);
                _repository.SaveChanges();

                return OperationResult<Actor>.CreateSuccessResult(new Actor());
            }
            catch (Exception ex)
            {
                return OperationResult<Actor>.CreateFailure(ex);
            }
        }

        public OperationResult<Actor> Find(long id)
        {
            try
            {
                var actor = _repository.ReadById((int)id);
                if (actor == null) return OperationResult<Actor>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<Actor>.CreateSuccessResult(actor);
            }
            catch (Exception ex)
            {
                return OperationResult<Actor>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<Actor>> GetAll()
        {
            try
            {
                var Actors = _repository.ReadAll();

                return OperationResult<IEnumerable<Actor>>.CreateSuccessResult(Actors);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Actor>>.CreateFailure(ex);
            }
        }

        public OperationResult<Actor> Save(Actor Actor)
        {
            try
            {
                _repository.Create(Actor);
                _repository.SaveChanges();
                return OperationResult<Actor>.CreateSuccessResult(Actor);
            }
            catch (Exception ex)
            {
                return OperationResult<Actor>.CreateFailure(ex);

            }
        }

        public OperationResult<Actor> Update(Actor Actor)
        {
            try
            {
                //var existingEntity = _repository.ReadById(Actor.Id);
                //if (existingEntity == null) return OperationResult<Actor>.CreateFailure(new ArgumentOutOfRangeException(nameof(Actor.Id)));

                _repository.Update(Actor);
                _repository.SaveChanges();
                return OperationResult<Actor>.CreateSuccessResult(Actor);
            }
            catch (Exception ex)
            {
                return OperationResult<Actor>.CreateFailure(ex);

            }
        }
    }
}

