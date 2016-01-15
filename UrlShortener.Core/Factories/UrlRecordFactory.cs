using UrlShortener.Core.Extensions;
using UrlShortener.Core.Objects;

namespace UrlShortener.Core.Factories
{
    public static class UrlRecordFactory
    {
        public static UrlRecord BuildUrlRecord(ShortUrlResponse response, string longUrl, string vanityUrl)
        {
            return new UrlRecord
            {
                ProviderReference = response.Reference,
                LongUrl = longUrl,
                ShortUrl = response.ShortUrl,
                VanityShortUrl = $"{vanityUrl}/{response.ShortUrl.GetUrlSuffix()}"
            };
        }
    }
}
