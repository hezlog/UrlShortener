using System;

namespace UrlShortener.Core.Objects
{
    public class UrlRecord
    {
        public int UrlRecordId { get; set; }
        public string ProviderReference { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }

        public UrlRecord()
        {
            UrlRecordId = 0;
            ProviderReference = null;
            LongUrl = null;
            ShortUrl = null;
            DateCreated = DateTime.UtcNow;
        }
    }
}
