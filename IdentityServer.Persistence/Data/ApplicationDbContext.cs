using IdentityServer.Application.Common.Interfaces;
using IdentityServer.Domain.Entities;
using IdentityServer.Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace IdentityServer.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ExternalApplications> Applications { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
