using IdentityServer.Application.Common.Interfaces;
using IdentityServer.Domain.Entities;
using IdentityServer.Persistence.Data;
using IdentityServer.Persistence.Data.DbInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<IdentityRole>>();

            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}
