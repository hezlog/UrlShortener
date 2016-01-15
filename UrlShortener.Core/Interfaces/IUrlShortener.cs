using UrlShortener.Core.Objects;

namespace UrlShortener.Core.Interfaces
{
    public interface IUrlShortener
    {
        ShortUrlResponse ShortenUrl(string longUrl);
    }
}
