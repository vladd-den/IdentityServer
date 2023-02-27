using IdentityServer.Application.Common.Interfaces;
using IdentityServer.Infrastructure.Configuration;
using IdentityServer.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetRequiredSection(nameof(JwtIssuerOptions));
            services.AddScoped<IJwtFactory, JwtFactory>();

            return services;

        }
    }
}
