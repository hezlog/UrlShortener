using System;

namespace UrlShortener.Core.Objects
{
    public class UrlRecord
    {
        public int UrlRecordId { get; set; }
        public string ProviderReference { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string VanityShortUrl { get; set; }
        public DateTime DateCreated { get; set; }

        public UrlRecord()
        {
            UrlRecordId = 0;
            ProviderReference = null;
            LongUrl = null;
            ShortUrl = null;
            VanityShortUrl = null;
            DateCreated = DateTime.UtcNow;
        }
    }
}
