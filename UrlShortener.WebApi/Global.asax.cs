using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using UrlShortener.DependencyInjection;

namespace UrlShortener.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureSimpleInjectorForWebApi();
            ConfigureSimpleInjectorForMvc();
        }

        private static void ConfigureSimpleInjectorForMvc()
        {
            var container = new Container();
            new MvcRegistry().RegisterServices(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }

        private static void ConfigureSimpleInjectorForWebApi()
        {
            var container = new Container();
            new WebApiRegistry().RegisterServices(container);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
