using SimpleInjector;
using SimpleInjector.Packaging;
using UrlShortener.Core.Interfaces;
using UrlShortener.Infrastructure;
using UrlShortener.Infrastructure.Data;

namespace UrlShortener.DependencyInjection
{
    public class Registry : IPackage
    {
        private const string ConnectionName = "UrlRecordContext";

        public void RegisterServices(Container container)
        {
            //Config
            container.RegisterWebApiRequest<IDbSettings>(() => new DbSettings(ConnectionName));

            //DbContext
            container.RegisterWebApiRequest<IUrlRecordContext>(() => new UrlRecordContext(container.GetInstance<IDbSettings>()));

            //Services
            container.Register<IRestClient, RestClient>();
            container.Register<IConfigurationService, ConfigurationService>();
            container.Register<IUrlService, Infrastructure.UrlService>();

            //Data
            container.Register<IUrlRecordRepository, UrlRecordRepository>();

            container.Verify();
        }
    }
}
