using Application.Contexts.Bases;
using Application.Models;
using Application.Services.Bases;
using Domain.Common.Results;
using Domain.Common.Results.Bases;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDb _db;

        public RoleService(IDb db)
        {
            _db = db;
        }

        public IQueryable<RoleModel> Read()
        {
            return _db.Roles.OrderBy(r => r.Name).Select(r => new RoleModel()
            {
                Command = new RoleCommandModel() // Edit
                {
                    Id = r.Id,
                    Name = r.Name,
                },
                Query = new RoleQueryModel() // List, Details, Delete
                {
                    Guid = r.Guid,
                    Id = r.Id,
                    Name = r.Name,
                    UserCount = r.Users.Count,
                    Users = string.Join("<br />", r.Users.OrderBy(u => u.UserName).Select(u => u.UserName))
                }
            });
        }

        public Result Create(RoleCommandModel command)
        {
            if (_db.Roles.Any(r => r.Name.ToLower() == command.Name.ToLower().Trim()))
                return new ErrorResult("Role with the same name exists!");
            Role role = new Role()
            {
                Name = command.Name.Trim()
            };
            _db.Roles.Add(role);
            _db.SaveChanges();
            return new SuccessResult();
        }

        public Result Update(RoleCommandModel command)
        {
            if (_db.Roles.Any(r => r.Id != command.Id && r.Name.ToLower() == command.Name.ToLower().Trim()))
                return new ErrorResult("Role with the same name exists!");
            Role role = _db.Roles.Find(command.Id);
            if (role is null)
                return new ErrorResult("Role not found!");
            role.Name = command.Name.Trim();
            _db.Roles.Update(role);
            _db.SaveChanges();
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            Role role = _db.Roles.Include(r => r.Users).SingleOrDefault(r => r.Id == id);
            if (role is null)
                return new ErrorResult("Role not found!");
            if (role.Users is not null && role.Users.Any())
                return new ErrorResult("Role can't be deleted because role has relational users!");
            _db.Roles.Remove(role);
            _db.SaveChanges();
            return new SuccessResult();
        }
    }
}
