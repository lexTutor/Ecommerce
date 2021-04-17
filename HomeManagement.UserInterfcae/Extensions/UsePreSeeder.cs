using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Extensions
{
    public static class UsePreSeeder
    {
        public static async System.Threading.Tasks.Task UsePreseeder(this IApplicationBuilder buildere, DataContext _ctx, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            await DataSeeder.SeedeRoles(_ctx, _roleManager);

            await DataSeeder.SeedFamily(_ctx);

            await DataSeeder.SeedeUsers(_ctx, _userManager);

            await DataSeeder.SeedTasks(_ctx);

            await DataSeeder.SeedTaskIssues(_ctx);

            await DataSeeder.SeedPersonalIssues(_ctx);

            await DataSeeder.SeedChat(_ctx);
        }
    }
}
