using IdentityServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Common.Interfaces
{
    public interface IJwtFactory
    {
        string GenerateJwtToken(User user, List<string> roles);
    }
}
