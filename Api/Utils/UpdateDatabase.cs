using Domain.Databases;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Utils;

public class UpdateDatabase
{
    public static async Task Execute(IApplicationBuilder app)
    {
        using var scope = app
            .ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            .CreateScope();
        using var context = scope.ServiceProvider.GetService<AppDbContext>();
        if (context is null)
            throw new ArgumentNullException(nameof(context));
        context.Database.EnsureCreated();
        List<Task> tasks = [];
        // UserRole[] userRoles = [];

        //check if there is no data in db then update db
        if (!(await context.Users.AnyAsync()))
        {
            await context.Users.AddRangeAsync(
                new User()
                {
                    RoleId = Guid.NewGuid(),
                    Name = "Phan Khai",
                    Email = "Khai@gmail.com",
                    Phone = "0963122758",
                },
                new User()
                {
                    RoleId = Guid.NewGuid(),
                    Name = "Thinh Pham",
                    Email = "Thinh@gmail.com",
                    Phone = "0967123456",
                }
            );
            await context.SaveChangesAsync();
        }
    }
}
