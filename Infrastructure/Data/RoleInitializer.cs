using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<AspUser> userManager, RoleManager<IdentityRole> roleManager, IServiceProvider serviceProvider)
        {
            using (var context = new VehicleDbContext(serviceProvider.GetRequiredService<DbContextOptions<VehicleDbContext>>()))
            {
                var role1 = context.Set<SystemRole>().FirstOrDefaultAsync(x => x.Name == "Админ");
                string roleS1 = role1.Result.Name;

                var role2 = await context.Set<SystemRole>().FirstOrDefaultAsync(x => x.Name == "Глава отдела");
                string roleS2 = role2.Name;

                var role3 = await context.Set<SystemRole>().FirstOrDefaultAsync(x => x.Name == "Специалист");
                string roleS3 = role3.Name;

                var empl1 = await context.Set<Employee>().FirstOrDefaultAsync(x => x.Id == 1);

                string email1 = "Pavl@gmail.com";
                string password1 = "123123123123";

                var empl2 = await context.Set<Employee>().FirstOrDefaultAsync(x => x.Id == 2);

                string email2 = "Serg@gmail.com";
                string password2 = "123412341234";


                AspUser aspUser1 = new AspUser() { EmployeeId = empl1.Id, UserName = email1, Email = email1 };
                AspUser aspUser2 = new AspUser() { EmployeeId = empl2.Id, UserName = email2, Email = email2 };

                if (await roleManager.FindByNameAsync("Админ") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleS1));
                }
                if (await roleManager.FindByNameAsync("Глава отдела") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleS2));
                }
                if (await roleManager.FindByNameAsync("Специалист") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleS3));
                }

                if (await userManager.FindByNameAsync(aspUser1.Email) == null)
                {
                    
                    IdentityResult result = await userManager.CreateAsync(aspUser1, password1);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(aspUser1, roleS1);
                    }
                }

                if (await userManager.FindByNameAsync(aspUser2.Email) == null)
                {

                    IdentityResult result = await userManager.CreateAsync(aspUser2, password2);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(aspUser2, roleS2);
                    }
                }
               
                await context.SaveChangesAsync();
            }

           
        }
    }
}
