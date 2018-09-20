using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLE.Entities.Models.AppModule
{
    public class AuthenticationInput
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool IsKeepSignedIn { get; set; }
    }
}
