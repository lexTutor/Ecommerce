using HomeManagement.DataAccess;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Extensions
{
    public static class IdentityConfiguration
    {
        public static void RegisterIdentityService(this IServiceCollection service)
        {

            service.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }
    }
}
