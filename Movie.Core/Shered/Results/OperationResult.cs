using System;

namespace Movie.Core.Shered.Results
{
    public class OperationResult<TResult>
    {
        private OperationResult() { }

        public bool Success { get; private set; }
        public TResult ResultData { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }

        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, ResultData = result };
        }

        public static OperationResult<TResult> CreateFailure(Exception ex)
        {
            return new OperationResult<TResult>
            {
                Success = false,
                //ErrorMessage = $"{ex.Message} {Environment.NewLine} {ex.StackTrace}",
                ErrorMessage = ex.Message,
                Exception = ex
            };
        }
    }
}
