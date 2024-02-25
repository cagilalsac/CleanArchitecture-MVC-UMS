using Application.Models;
using Domain.Common.Results.Bases;

namespace Application.Services.Bases
{
    public interface IUserService
    {
        IQueryable<UserModel> Read();
        public IQueryable<UserQueryModel> GetQuery() => Read().Select(q => q.Query);
        public IQueryable<UserCommandModel> GetCommand() => Read().Select(q => q.Command);
        Result Create(UserCommandModel command);
		Result Update(UserCommandModel command);
		Result Delete(int id);
    }
}
