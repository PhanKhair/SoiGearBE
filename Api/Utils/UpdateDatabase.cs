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

        //check if there is no data in db then update db
        if (!(await context.Users.AnyAsync()))
        {
            await context.Roles.AddRangeAsync(
                new Role()
                {
                    Id = Guid.Parse("d6933087-9e1d-483a-b5d4-15cf53939f1a"),
                    Name = "Admin",
                },
                new Role()
                {
                    Id = Guid.Parse("ba320be4-ff9a-44ef-b2d4-d845cdc52815"),
                    Name = "User",
                }
            );

            await context.Users.AddRangeAsync(
                new User()
                {
                    Id = Guid.Parse("36c0c3bf-2e43-41a1-8a83-49f330f20ebf"),
                    RoleId = Guid.Parse("d6933087-9e1d-483a-b5d4-15cf53939f1a"),
                    Name = "Phan Khai",
                    Email = "Khai@gmail.com",
                    Phone = "0963122758",
                    Status = true,
                },
                new User()
                {
                    Id = Guid.Parse("b6f2f10c-0400-411f-a0cd-0312bd778912"),
                    RoleId = Guid.Parse("ba320be4-ff9a-44ef-b2d4-d845cdc52815"),
                    Name = "Thinh Pham",
                    Email = "Thinh@gmail.com",
                    Phone = "0967123456",
                    Status = true,
                }
            );

            await context.Keyboards.AddRangeAsync(
                new Keyboard()
                {
                    Id = Guid.Parse("5106e76c-b588-405a-8019-14007dffbbda"),
                    Name = "Dune65",
                    Description = "Phím đẹp vãi chưởng",
                    Price = 500,
                    Discount = 12,
                }
            );

            await context.UserKeyboards.AddRangeAsync(
                new UserKeyboard()
                {
                    UserId = Guid.Parse("b6f2f10c-0400-411f-a0cd-0312bd778912"),
                    KeyboardId = Guid.Parse("5106e76c-b588-405a-8019-14007dffbbda"),
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
