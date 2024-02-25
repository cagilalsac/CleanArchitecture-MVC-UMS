using Domain.Common.Results.Bases;

namespace Domain.Common.Results
{
	public class SuccessResult : Result
	{
		public SuccessResult(string? message) : base(true, message)
		{
		}

        public SuccessResult() : base(true, default)
        {
        }
    }
}
