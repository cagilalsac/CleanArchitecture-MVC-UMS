using Application.Contexts.Bases;
using Application.Models;
using Application.Services.Bases;
using Domain.Common.Results;
using Domain.Common.Results.Bases;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class UserService : IUserService
	{
		private readonly IDb _db;

		public UserService(IDb db)
		{
			_db = db;
		}

		public IQueryable<UserModel> Read()
		{
			return _db.Users.Include(u => u.Role).OrderByDescending(u => u.IsActive).ThenBy(u => u.UserName).Select(u => new UserModel()
			{
				Command = new UserCommandModel() // Edit
				{
					Id = u.Id,
                    UserName = u.UserName,
                    Password = u.Password,
                    Sex = u.Sex,
					BirthDate = u.BirthDate,
					IsActive = u.IsActive,
                    RoleId = u.RoleId
				},
				Query = new UserQueryModel() // List, Details, Delete
				{
                    Id = u.Id,
                    Guid = u.Guid,
                    UserName = u.UserName,
                    Sex = u.Sex,
                    BirthDate = u.BirthDate.ToString("MM/dd/yyyy"),
                    Active = u.IsActive ? "Yes" : "No",
                    Role = u.Role.Name,
                }
			});
		}

		public Result Create(UserCommandModel command)
		{
			if (_db.Users.Any(u => u.UserName.ToLower() == command.UserName.ToLower().Trim()))
				return new ErrorResult("User with the same user name exists!");
			User user = new User()
			{
				BirthDate = command.BirthDate.Value,
				RoleId = command.RoleId ?? 0,
				IsActive = command.IsActive,
				Password = command.Password.Trim(),
				Sex = command.Sex,
				UserName = command.UserName.Trim()
			};
			_db.Users.Add(user);
			_db.SaveChanges();
			command.Id = user.Id;
			return new SuccessResult("User added successfully.");
		}

		public Result Update(UserCommandModel command)
		{
			if (_db.Users.Any(u => u.Id != command.Id && u.UserName.ToLower() == command.UserName.ToLower().Trim()))
				return new ErrorResult("User with the same user name exists!");
			User user = _db.Users.Find(command.Id);
			if (user is null)
				return new ErrorResult("User not found!");
			user.BirthDate = command.BirthDate.Value;
			user.RoleId = command.RoleId ?? 0;
			user.IsActive = command.IsActive;
			user.Password = command.Password.Trim();
			user.Sex = command.Sex;
			user.UserName = command.UserName.Trim();
			_db.Users.Update(user);
			_db.SaveChanges();
			return new SuccessResult("User updated successfully.");
		}

		public Result Delete(int id)
		{
			User user = _db.Users.Find(id);
			if (user is null)
				return new ErrorResult("User not found!");
			_db.Users.Remove(user);
			_db.SaveChanges();
			return new SuccessResult("User deleted successfully.");
		}
	}
}
