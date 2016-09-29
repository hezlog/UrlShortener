// ReSharper disable InconsistentNaming
namespace UrlShortener.Core.Objects
{
    public class ShortUrlResponse
    {
        public string id { get; set; }
        public string title { get; set; }
        public string slashtag { get; set; }
        public string destination { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string shortUrl { get; set; }
        public Domain domain { get; set; }
    }

    public class Domain
    {
        public string id { get; set; }
        public string _ref { get; set; }
    }
}
