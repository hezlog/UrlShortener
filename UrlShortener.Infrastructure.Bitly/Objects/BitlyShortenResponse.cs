namespace UrlShortener.Infrastructure.Bitly.Objects
{
    public class BitlyShortenResponse
    {
        public string status_code { get; set; }
        public string status_txt { get; set; }
        public ShortenData data { get; set; }
    }
}
