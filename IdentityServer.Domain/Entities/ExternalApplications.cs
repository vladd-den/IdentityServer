using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Domain.Entities
{
    public class ExternalApplications
    {
        public Guid Id { get; set; }
        public string ApplicationName { get; set; }
    }
}
