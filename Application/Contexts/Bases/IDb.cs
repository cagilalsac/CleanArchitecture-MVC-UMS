using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contexts.Bases
{
    public interface IDb
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        int SaveChanges();
    }
}
