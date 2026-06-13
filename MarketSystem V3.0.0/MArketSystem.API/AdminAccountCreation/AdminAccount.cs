using MarketSystem.DAL.Data.Models;
using MArketSystem.API.Roles;
using Microsoft.AspNetCore.Identity;

namespace MArketSystem.API.AdminAccountCreation
{
    public static class AdminAccount
    {
        public static async Task CreateAccountAdmin(IServiceProvider servideprovider)
        {
            var Roles = new ApplicatioRoles();
            var _usermanager = servideprovider.GetRequiredService<UserManager<ApplicationUser>>();
            var _rolemanager = servideprovider.GetRequiredService<RoleManager<IdentityRole>>();

            var IsRoleExist = await _rolemanager.RoleExistsAsync(Roles.Admin);
            if (!IsRoleExist)
              await _rolemanager.CreateAsync(new IdentityRole { Name = Roles.Admin });

            var FName = "Rawan";
            var LName = "Ramadan";
            var UEmail = "rawan@gmail.com";
            var User_Name = "Rawan_291";
            var pass = "29102023";

            var UserExisting = await _usermanager.FindByEmailAsync(UEmail);
            if (UserExisting == null) {
                var user = new ApplicationUser
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = UEmail,
                    UserName = User_Name

                };
                var ResultOfCreatingAdminAccount=await _usermanager.CreateAsync(user,pass);
                await _usermanager.AddToRoleAsync(user, Roles.Admin);
            }
           

        }
    }
}
