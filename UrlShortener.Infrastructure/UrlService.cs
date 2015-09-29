using System;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Objects;
using UrlShortener.Infrastructure.Data.Mapping;
using IRestClient = UrlShortener.Core.Interfaces.IRestClient;

namespace UrlShortener.Infrastructure
{
    public class UrlService : IUrlService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IRestClient _restClient;
        private readonly IUrlRecordRepository _urlRecordRepository;

        public UrlService(IConfigurationService configurationService, IRestClient restClient, IUrlRecordRepository urlRecordRepository)
        {
            _configurationService = configurationService;
            _restClient = restClient;
            _urlRecordRepository = urlRecordRepository;
        }

        public string ShortenUrl(string longUrl)
        {
            var api = _configurationService.GetSetting("BitlyUrl");
            var accessToken = _configurationService.GetSetting("BitlyAccessToken");

            var uri = new Uri($"{api}/v3/shorten?access_token={accessToken}&longUrl={longUrl}");
            var json = _restClient.Get(uri);
            var bitlyResponse = _restClient.Deserialize<BitlyResponse>(json);

            var record = UrlMapper.BitlyResponseToUrlRecord(bitlyResponse);

            _urlRecordRepository.CreateUrlRecord(record);

            return bitlyResponse.data.url;
        }
    }
}
