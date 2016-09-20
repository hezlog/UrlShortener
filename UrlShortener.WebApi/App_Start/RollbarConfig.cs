using System.Web.Http;
using Rollbar.WebAPI.Filters;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(UrlShortener.WebApi.RollbarConfig), "Register")]

namespace UrlShortener.WebApi
{
    public class RollbarConfig
    {
        public static void Register()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                GlobalConfiguration.Configuration.Filters.Add(new RollbarExceptionFilter());
            }
        }
    }
}
