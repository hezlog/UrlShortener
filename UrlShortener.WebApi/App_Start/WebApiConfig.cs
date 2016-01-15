using System.Web.Http;
using System.Web.Http.Cors;
using Antlr.Runtime.Misc;

namespace UrlShortener.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes();
        }
    }
}
