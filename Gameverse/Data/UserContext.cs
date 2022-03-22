using Microsoft.EntityFrameworkCore;
using Gameverse.Models;

namespace Gameverse.Data;

public class UserContext : DbContext
{
    public UserContext (DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
}