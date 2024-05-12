using BlogT53.Core.Domain.Identity;
using BlogT53.Data.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogT53.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(BlogT53Context context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    DisplayName = "Quản trị viên"
                });

                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var user = new AppUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "zhu",
                    LastName = "li",
                    Email = "jackychau157@gmail.com",
                    NormalizedEmail = "jackychau157@gmail.com",
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now,
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@12345");

                await context.Users.AddAsync(user);
                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>
                {
                    RoleId = rootAdminRoleId,
                    UserId = user.Id
                });
                await context.SaveChangesAsync();
            }
        }
    }
}