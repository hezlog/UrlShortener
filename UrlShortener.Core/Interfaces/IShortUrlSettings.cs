namespace UrlShortener.Core.Interfaces
{
    public interface IShortUrlSettings
    {
        string HomepageUrl { get; }
        string VanityUrl { get; }
        string ExternalUrl { get; }
    }
}
