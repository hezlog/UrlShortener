using System.Configuration;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Infrastructure
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
