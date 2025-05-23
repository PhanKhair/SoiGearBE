using Domain.Databases;
using Domain.Entities;
using Domain.Enums;
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
            // ROLE
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

            // CATEGORY
            await context.Categories.AddRangeAsync(
                new Category()
                {
                    Id = Guid.Parse("e6139dda-b007-49aa-866a-8e681b487d69"),
                    Name = "GroupBuy",
                    Description = "Hàng order",
                },
                new Category()
                {
                    Id = Guid.Parse("0b899b7a-fa7c-4466-883b-657ebd1f919e"),
                    Name = "Store",
                    Description = "Hàng có sẵn",
                }
            );

            // USER
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

            // KEYBOARD
            await context.Keyboards.AddRangeAsync(
                new Keyboard()
                {
                    Id = Guid.Parse("5106e76c-b588-405a-8019-14007dffbbda"),
                    CategoryId = Guid.Parse("e6139dda-b007-49aa-866a-8e681b487d69"),
                    Name = "Dune65",
                    Description = "Phím nhôm",
                    Price = 9850000,
                    Discount = 5,
                    Status = true,
                },
                new Keyboard()
                {
                    Id = Guid.Parse("4a7f178c-01f2-4a8c-b136-84759ffedc94"),
                    CategoryId = Guid.Parse("0b899b7a-fa7c-4466-883b-657ebd1f919e"),
                    Name = "F1 TKL",
                    Description = "Phím đẹp vãi chưởng",
                    Price = 12400405,
                    Discount = 7,
                    Status = true,
                }
            );

            // SWITCH
            await context.Switches.AddRangeAsync(
                new Switch()
                {
                    Id = Guid.Parse("79ec005e-9ad3-45d5-b24b-12928a0a2d8e"),
                    CategoryId = Guid.Parse("0b899b7a-fa7c-4466-883b-657ebd1f919e"),
                    Name = "HMX Xinhai",
                    Description = "Switch âm đanh, nổ to của nhà HMX",
                    SwitchType = SwitchType.Linear,
                    PreTravel = 2.0f,
                    TotalTravel = 3.4f,
                    BottomOut = 45f,
                    MountingPin = 5,
                    Price = 4000,
                    Discount = 5,
                    Status = true,
                },
                new Switch()
                {
                    Id = Guid.Parse("ff1d708b-eb56-45fd-b730-c991320f046e"),
                    CategoryId = Guid.Parse("e6139dda-b007-49aa-866a-8e681b487d69"),
                    Name = "Owlab Neon",
                    Description = "Batch mới nhất đã sửa lỗi dọng dầu lube gây tịt âm",
                    SwitchType = SwitchType.Linear,
                    PreTravel = 2.1f,
                    TotalTravel = 3.5f,
                    BottomOut = 62f,
                    MountingPin = 5,
                    Price = 11000,
                    Discount = 5,
                    Status = true,
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
