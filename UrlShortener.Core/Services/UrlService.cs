using Conditions;
using Conditions.Guards;
using UrlShortener.Core.Factories;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Core.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRecordRepository _urlRecordRepository;
        private readonly IShortUrlSettings _shortUrlSettings;
        private readonly IUrlShortener _urlShortener;

        public UrlService(IUrlRecordRepository urlRecordRepository, IShortUrlSettings shortUrlSettings, IUrlShortener urlShortener)
        {
            Check.If(urlRecordRepository).IsNotNull();
            Check.If(shortUrlSettings).IsNotNull();
            Check.If(urlShortener).IsNotNull();

            _urlRecordRepository = urlRecordRepository;
            _shortUrlSettings = shortUrlSettings;
            _urlShortener = urlShortener;
        }

        public string ShortenUrl(string longUrl)
        {
            var shortUrl = _urlShortener.ShortenUrl(longUrl);

            var url = UrlRecordFactory.BuildUrlRecord(shortUrl, longUrl, _shortUrlSettings.VanityUrl);

            _urlRecordRepository.CreateUrlRecord(url);

            return url.VanityShortUrl;
        }

        public string GetShortUrl(string linkId)
        {
            if (linkId.IsNullOrEmpty())
                return _shortUrlSettings.HomepageUrl;

            return UrlFactory.BuildShortUrl(_shortUrlSettings.ExternalUrl, linkId);
        }
    }
}
