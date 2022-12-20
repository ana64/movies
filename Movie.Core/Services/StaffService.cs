using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;
using System.Collections.Generic;

namespace Movie.Core.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _repository;

        public StaffService(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public OperationResult<Staff> Delete(long id)
        {
            try
            {
                var StaffToDelete = _repository.ReadById((int)id);
                if (StaffToDelete == null) return OperationResult<Staff>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                _repository.Delete(StaffToDelete.Id);

                return OperationResult<Staff>.CreateSuccessResult(new Staff());
            }
            catch (Exception ex)
            {
                return OperationResult<Staff>.CreateFailure(ex);
            }
        }

        public OperationResult<Staff> Find(long id)
        {
            try
            {
                var category = _repository.ReadById((int)id);
                if (category == null) return OperationResult<Staff>.CreateFailure(new ArgumentOutOfRangeException(nameof(id)));

                return OperationResult<Staff>.CreateSuccessResult(category);
            }
            catch (Exception ex)
            {
                return OperationResult<Staff>.CreateFailure(ex);

            }
        }

        public OperationResult<IEnumerable<Staff>> GetAll()
        {
            try
            {
                var Staffs = _repository.ReadAll();

                return OperationResult<IEnumerable<Staff>>.CreateSuccessResult(Staffs);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<Staff>>.CreateFailure(ex);
            }
        }

        public OperationResult<Staff> Save(Staff Staff)
        {
            try
            {
                _repository.Create(Staff);
                _repository.SaveChanges();
                return OperationResult<Staff>.CreateSuccessResult(Staff);
            }
            catch (Exception ex)
            {
                return OperationResult<Staff>.CreateFailure(ex);

            }
        }

        public OperationResult<Staff> Update(Staff Staff)
        {
            try
            {
               
                _repository.Update(Staff);
                _repository.SaveChanges();
                return OperationResult<Staff>.CreateSuccessResult(Staff);
            }
            catch (Exception ex)
            {
                return OperationResult<Staff>.CreateFailure(ex);

            }
        }
    }
}
