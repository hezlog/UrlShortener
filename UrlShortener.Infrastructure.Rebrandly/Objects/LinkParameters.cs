// ReSharper disable InconsistentNaming

namespace UrlShortener.Infrastructure.Rebrandly.Objects
{
    public class LinkParameters
    {
        public string destination { get; set; }
        public string slashtag { get; set; }
        public string title { get; set; }
        public Domain domain { get; set; }
        public string description { get; set; }
    }
}
