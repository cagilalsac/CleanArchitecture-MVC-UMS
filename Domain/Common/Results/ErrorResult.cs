using Domain.Common.Results.Bases;

namespace Domain.Common.Results
{
	public class ErrorResult : Result
	{
		public ErrorResult(string? message) : base(false, message)
		{
		}

		public ErrorResult() : base(false, default)
		{
		}
	}
}
