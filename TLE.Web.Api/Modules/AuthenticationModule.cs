using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLE.Entities.Models.AppModule;
using TLE.Service;

namespace TLE.Web.Api.Modules
{
    public class AuthenticationModule: BaseModule
    {
        public AuthenticationModule(UserService userService)
            :base("/api/authentication", false)
        {
            Post<AuthenticationInput, LoginResponse>("/login", async (input) => await userService.Login(input), false);
        }

    }
}
