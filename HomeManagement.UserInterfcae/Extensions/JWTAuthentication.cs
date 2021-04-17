using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.UserInterface.Extensions
{
    public static class JWTAuthentication
    {
        public static void UseJWTAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["JWTConfigurations:Issuer"],
                    ValidAudience = config["JWTConfigurations:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTConfigurations:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }


        public static void UseAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(configure =>
            {
                configure.AddPolicy(Policies.Policies.Parent, Policies.Policies.ParentPolicy());
                configure.AddPolicy(Policies.Policies.Guardian, Policies.Policies.GuardianPolicy());
                configure.AddPolicy(Policies.Policies.Child, Policies.Policies.ChildPolicy());
            });
        }
    }
}
