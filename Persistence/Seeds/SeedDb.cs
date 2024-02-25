using Domain.Common.Enums;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Persistence.Seeds
{
    public class SeedDb
    {
        public void Initialize()
        {
            var dbFactory = new DbFactory();
            var db = dbFactory.CreateDbContext([]);

            var users = db.Users.ToList();
            db.Users.RemoveRange(users);

            var roles = db.Roles.ToList();
            db.Roles.RemoveRange(roles);

            if (roles.Count > 0) 
            {
                db.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Roles', RESEED, 0)"); 
            }

            db.Roles.Add(new Role()
            {
                Name = "Admin",
                Users = new List<User>()
                {
                    new User()
                    {
                        IsActive = true,
                        Password = "cagil",
                        UserName = "cagil",
                        BirthDate = new DateTime(1980, 5, 27),
                        Sex = Sex.Man
                    }
                }
            });
            db.Roles.Add(new Role()
            {
                Name = "User",
                Users = new List<User>()
                {
                    new User()
                    {
                        IsActive = true,
                        Password = "luna",
                        UserName = "luna",
                        BirthDate = DateTime.Parse("23.09.2022", new CultureInfo("tr-TR")),
                        Sex = Sex.Woman
                    }
                }
            });

            db.SaveChanges();
        }
    }
}
