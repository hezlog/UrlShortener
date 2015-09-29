using System.Web.Http;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.WebApi.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost, Route("shorten")]
        public string ShortenLongUrl(LongUrl url)
        {
            var shortUrl = _urlService.ShortenUrl(url.Value);
            return shortUrl;
        }

        public class LongUrl
        {
            public string Value { get; set; }
        }
    }
}
