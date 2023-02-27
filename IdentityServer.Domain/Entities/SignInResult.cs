using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Domain.Entities
{
    public class SignInResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
        public string AccessToken { get; set; }
    }
}
