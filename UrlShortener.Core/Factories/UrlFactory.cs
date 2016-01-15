namespace UrlShortener.Core.Factories
{
    public static class UrlFactory
    {
        public static string BuildShortUrl(string urlPrefix, string linkId)
        {
            return $"{urlPrefix}/{linkId}";
        }
    }
}
