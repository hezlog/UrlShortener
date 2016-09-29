using System;
using Conditions;
using Conditions.Guards;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using UrlShortener.Infrastructure.Rebrandly.Objects;

namespace UrlShortener.Infrastructure.Rebrandly
{
    public class RebrandlyUrlShortener : IUrlShortener
    {
        private readonly IConfigurationService _configurationService;
        private readonly IRestClient _restClient;

        public RebrandlyUrlShortener(IConfigurationService configurationService, IRestClient restClient)
        {
            Check.If(configurationService).IsNotNull();
            Check.If(restClient).IsNotNull();

            _configurationService = configurationService;
            _restClient = restClient;
        }

        public ShortUrlResponse ShortenUrl(string longUrl)
        {
            Check.If(longUrl).IsNotNullOrEmpty();

            var api = _configurationService.GetSetting("RebrandlyUrl");

            var domainId = _configurationService.GetSetting("RebrandlyDomainId");
            var parameters = new LinkParameters
            {
                destination = longUrl,
                domain = new Objects.Domain {id = $"{domainId}", @ref = $"/domains/{domainId}"}
            };

            var uri = new Uri($"{api}/links");

            var json = _restClient.Post(uri, parameters);
            var response = _restClient.Deserialize<ShortUrlResponse>(json);

            return response.destination.IsNullOrEmpty() ? null : response;
        }
    }
}
