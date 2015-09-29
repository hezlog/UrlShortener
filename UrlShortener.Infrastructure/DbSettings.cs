using System.Configuration;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Infrastructure
{
    public class DbSettings : IDbSettings
    {
        private readonly string _connectionName;
        public DbSettings(string connectionName)
        {
            _connectionName = connectionName;
        }
        public string ConnectionString => ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
    }
}
