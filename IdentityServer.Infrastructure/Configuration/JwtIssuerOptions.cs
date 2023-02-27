using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure.Configuration
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int ValidForMinutes { get; set; }
        public DateTime IssuedAt => DateTime.UtcNow;
        public DateTime NotBefore => IssuedAt;
        public DateTime Expiration => IssuedAt.Add(TimeSpan.FromMinutes(ValidForMinutes));
    }
}
