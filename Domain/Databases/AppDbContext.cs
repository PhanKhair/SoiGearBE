using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Databases;

public class AppDbContext(DbContextOptions context) : DbContext(context)
{
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Keyboard> Keyboards => Set<Keyboard>();
    public DbSet<Switch> Switches => Set<Switch>();
}
