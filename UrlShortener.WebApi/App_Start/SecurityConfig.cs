using System.Web.Http;
using ApiSecurity.Filters;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(UrlShortener.WebApi.SecurityConfig), "Register")]

namespace UrlShortener.WebApi
{
    public class SecurityConfig
    {
        public static void Register()
        {
		    GlobalConfiguration.Configuration.Filters.Add(new RequireHttpsAttribute());
			GlobalConfiguration.Configuration.Filters.Add(new IdentityBasicAuthenticationAttribute());
			GlobalConfiguration.Configuration.Filters.Add(new AuthorizeAttribute());
        }
    }
}
