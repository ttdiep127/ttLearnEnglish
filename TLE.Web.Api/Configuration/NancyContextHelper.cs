using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLE.Web.Api.Configuration
{
    public static class NancyContextHelper
    {
        public static int UserId(this NancyContext context)
        {
            return Convert.ToInt32(context.CurrentUser?.Identities?.FirstOrDefault(_ => _.Label == "UserId")?.BootstrapContext);
        }

        public static string UserEmail(this NancyContext context)
        {
            return Convert.ToString(context.CurrentUser?.Identities?.FirstOrDefault()?.Name);
        }

        public static string UserFullName(this NancyContext context)
        {
            return Convert.ToString(context.CurrentUser?.Identities?.FirstOrDefault(_ => _.Label == "FullName")?.BootstrapContext);
        }

        public static string AccessToken(this NancyContext context)
        {
            return context?.Request?.Headers?.Authorization;
        }
    }
}
