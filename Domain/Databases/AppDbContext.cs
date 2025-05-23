using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Databases;

public class AppDbContext(DbContextOptions context) : DbContext(context)
{
    public DbSet<User> Users => Set<User>();
}
