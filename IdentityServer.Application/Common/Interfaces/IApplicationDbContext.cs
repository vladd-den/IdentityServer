﻿using IdentityServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<ExternalApplications> Applications { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
