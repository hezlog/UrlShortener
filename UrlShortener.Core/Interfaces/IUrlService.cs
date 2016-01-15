namespace UrlShortener.Core.Interfaces
{
    public interface IUrlService
    {
        string ShortenUrl(string longUrl);
        string GetShortUrl(string linkId);
    }
}
