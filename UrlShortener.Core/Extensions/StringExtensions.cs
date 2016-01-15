using System.Linq;

namespace UrlShortener.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetUrlSuffix(this string url)
        {
            var segments = url.Split('/');

            return segments.Last();
        }
    }
}
