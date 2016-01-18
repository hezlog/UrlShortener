namespace UrlShortener.Core.Interfaces
{
    public interface IShortUrlSettings
    {
        string HomepageUrl { get; }
        string ExternalUrl { get; }
        bool VanityUrlEnabled { get; }
        string VanityUrl { get; }
    }
}
