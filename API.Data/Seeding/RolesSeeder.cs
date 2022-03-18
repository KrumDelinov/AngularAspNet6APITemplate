namespace API.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using API.Common;
    using API.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class RolesSeeder : ISeeder
    {

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(roleManager, userManager, GlobalConstants.AdministratorRoleName);

            await SeedRoleAsync(roleManager, userManager, GlobalConstants.CookRoleName);

            await SeedRoleAsync(roleManager, userManager, GlobalConstants.WaiterRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser
                {
                    FirstName = "Krum",
                    LastName = "Delinov",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0888123456",
                    EmailConfirmed = true,
                };

            

                var password = "123456";

                var result1 = await userManager.CreateAsync(user1, password);

                if (result1.Succeeded )
                {
                    await userManager.AddToRoleAsync(user1, GlobalConstants.AdministratorRoleName);
                 
                }
            }
        }
    }
}
