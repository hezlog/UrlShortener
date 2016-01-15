using System;
using System.Linq;
using Conditions.Guards;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using UrlShortner.Infrastructure.Bitly.Objects;
using BitlyShortenResponse = UrlShortner.Infrastructure.Bitly.Objects.BitlyShortenResponse;

namespace UrlShortner.Infrastructure.Bitly
{
    public class BitlyUrlShortner : IUrlShortener
    {
        private readonly IConfigurationService _configurationService;
        private readonly IRestClient _restClient;

        public BitlyUrlShortner(IConfigurationService configurationService, IRestClient restClient)
        {
            Check.If(configurationService).IsNotNull();
            Check.If(restClient).IsNotNull();

            _configurationService = configurationService;
            _restClient = restClient;
        }

        public ShortUrlResponse ShortenUrl(string longUrl)
        {
            var api = _configurationService.GetSetting("BitlyUrl");
            var accessToken = _configurationService.GetSetting("BitlyAccessToken");

            var uri = new Uri($"{api}/v3/shorten?access_token={accessToken}&longUrl={longUrl}");

            var json = _restClient.Get(uri);

            var bitlyResponse = _restClient.Deserialize<BitlyShortenResponse>(json);

            return new ShortUrlResponse {Reference = bitlyResponse.data.hash, ShortUrl = bitlyResponse.data.url};
        }
    }
}
