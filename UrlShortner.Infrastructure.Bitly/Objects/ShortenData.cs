namespace UrlShortner.Infrastructure.Bitly.Objects
{
    public class ShortenData
    {
        public string long_url { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string global_hash { get; set; }
        public string new_hash { get; set; }
    }
}