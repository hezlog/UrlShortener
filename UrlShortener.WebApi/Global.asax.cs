using System.Web;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using UrlShortener.DependencyInjection;

namespace UrlShortener.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureSimpleInjector();
        }

        private static void ConfigureSimpleInjector()
        {
            var container = new Container();
            new Registry().RegisterServices(container);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
