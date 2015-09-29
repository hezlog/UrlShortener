using System.Data.Entity;
using UrlShortener.Core.Objects;

namespace UrlShortener.Infrastructure.Data
{
    public interface IUrlRecordContext
    {
        DbSet<UrlRecord> Records { get; set; }
        int SaveChanges();
    }
}
