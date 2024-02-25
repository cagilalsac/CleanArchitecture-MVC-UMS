using Application.Models;
using Domain.Common.Results.Bases;

namespace Application.Services.Bases
{
    public interface IRoleService
    {
        IQueryable<RoleModel> Read();
        public IQueryable<RoleQueryModel> GetQuery() => Read().Select(q => q.Query);
        public IQueryable<RoleCommandModel> GetCommand() => Read().Select(q => q.Command);
        Result Create(RoleCommandModel command);
        Result Update(RoleCommandModel command);
        Result Delete(int id);

        public List<RoleQueryModel> GetQueryList() => GetQuery().ToList();
        public RoleQueryModel? GetQueryItem(int id) => GetQuery().SingleOrDefault(q => q.Id == id);
        public RoleCommandModel? GetCommandItem(int id) => GetCommand().SingleOrDefault(q => q.Id == id);
    }
}
