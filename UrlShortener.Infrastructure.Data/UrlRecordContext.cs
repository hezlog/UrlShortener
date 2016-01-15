using System.Data.Entity;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using UrlShortener.Infrastructure.Data.Mapping;

namespace UrlShortener.Infrastructure.Data
{
    public class UrlRecordContext : DbContext, IUrlRecordContext
    {
        public UrlRecordContext(IDbSettings connectionSettings)
            : base(connectionSettings.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public UrlRecordContext()
            : base(Constants.DefaultDatabaseName)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UrlRecord> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Address
            modelBuilder.Configurations.Add(new UrlRecordMap());
        }
    }
}
