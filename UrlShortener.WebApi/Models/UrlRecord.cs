using System;

namespace UrlShortener.WebApi.Models
{
    public class UrlRecord
    {
        public int RecordId { get; set; }
        public string ProviderReference { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}