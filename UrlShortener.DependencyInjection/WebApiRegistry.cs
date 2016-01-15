using System.Configuration;
using SimpleInjector;
using SimpleInjector.Packaging;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using UrlShortener.Core.Services;
using UrlShortener.Infrastructure;
using UrlShortener.Infrastructure.Data;
using UrlShortener.Infrastructure.Bitly;

namespace UrlShortener.DependencyInjection
{
    public class WebApiRegistry : IPackage
    { 

        public void RegisterServices(Container container)
        {
            //Config
            container.RegisterWebApiRequest<IDbSettings>(() => new DbSettings(Constants.ConnectionName));
            container.RegisterWebApiRequest<IShortUrlSettings>(() => (ShortUrlSettings)(dynamic)ConfigurationManager.GetSection(Constants.ShortUrlSettingsSectionName));

            //DbContext
            container.RegisterWebApiRequest<IUrlRecordContext>(() => new UrlRecordContext(container.GetInstance<IDbSettings>()));

            //Services
            container.Register<IConfigurationService, ConfigurationService>();
            container.Register<IUrlService, UrlService>();

            //External Service
            container.Register<IRestClient, RestClient>();
            container.Register<IUrlShortener, BitlyUrlShortner>();

            //Data
            container.Register<IUrlRecordRepository, UrlRecordRepository>();

            container.Verify();
        }
    }
}
