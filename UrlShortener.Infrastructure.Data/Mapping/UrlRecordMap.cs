using System.Data.Entity.ModelConfiguration;
using UrlShortener.Core.Objects;

namespace UrlShortener.Infrastructure.Data.Mapping
{
    public class UrlRecordMap : EntityTypeConfiguration<UrlRecord>
    {
        public UrlRecordMap()
        {
            Property(x => x.ProviderReference)
                .HasMaxLength(50);

            Property(x => x.ShortUrl)
                .HasMaxLength(50);

            Property(x => x.VanityShortUrl)
                .HasMaxLength(50);
        }
    }
}
