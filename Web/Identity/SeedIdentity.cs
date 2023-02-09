using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace webui.Identity
{
    public static class SeedIdentity  //otoomatik bir admin oluşturma
    {
        public static async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new IdentityUser
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}