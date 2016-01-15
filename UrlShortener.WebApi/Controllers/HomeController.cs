using System.Web.Mvc;
using Conditions.Guards;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlService _urlService;

        public HomeController(IUrlService urlService)
        {
            Check.If(urlService).IsNotNull();

            _urlService = urlService;
        }

        public ActionResult Index(string linkId)
        {
            Response.StatusCode = 302;
            Response.RedirectLocation = _urlService.GetShortUrl(linkId);
            
            return new ContentResult();
        }
    }
}
