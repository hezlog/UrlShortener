using UrlShortener.Core.Objects;

namespace UrlShortener.Infrastructure.Data.Mapping
{
    public class UrlMapper
    {
        public static UrlRecord BitlyResponseToUrlRecord(BitlyResponse response)
        {
            var record = new UrlRecord
            {
                LongUrl = response.data.long_url,
                ShortUrl = response.data.url,
                ProviderReference = response.data.hash
            };
            return record;
        }
    }
}
