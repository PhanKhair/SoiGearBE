using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Databases;

public class AppDbContext(DbContextOptions context) : DbContext(context)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Keyboard> Keyboards => Set<Keyboard>();
    public DbSet<UserKeyboard> UserKeyboards => Set<UserKeyboard>();
}
