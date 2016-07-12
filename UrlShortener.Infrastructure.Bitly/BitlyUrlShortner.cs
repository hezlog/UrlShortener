using System;
using Conditions.Guards;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using BitlyShortenResponse = UrlShortener.Infrastructure.Bitly.Objects.BitlyShortenResponse;

namespace UrlShortener.Infrastructure.Bitly
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

            if (bitlyResponse == null)
                return new ShortUrlResponse {Reference = string.Empty, ShortUrl = longUrl};

            return new ShortUrlResponse {Reference = bitlyResponse.data.hash, ShortUrl = bitlyResponse.data.url};
        }
    }
}
